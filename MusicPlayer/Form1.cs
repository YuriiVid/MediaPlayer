using MusicPlayer.Properties;
using LibVLCSharp.Shared;
using System;
using System.Threading;
using System.Reflection;
using System.Timers;
using System.Globalization;
using System.ComponentModel;

namespace MusicPlayer
{
	public partial class MusicPlayerApp : Form
	{
		private LibVLC _libVLC;
		private MediaPlayer _mp;
		private Media _media;

		private bool _isFullScreen = false;
		private int _previousVolume;
		private Size _oldFormSize;
		private Size _oldVideoSize;
		private Point _oldVideoLocation;

		public MusicPlayerApp()
		{
			InitializeComponent();
			Core.Initialize();
			_oldVideoSize = videoView1.Size;
			_oldFormSize = Size;
			_oldVideoLocation = videoView1.Location;
			//VLC 
			_libVLC = new LibVLC();
			_mp = new MediaPlayer(_libVLC);
			videoView1.MediaPlayer = _mp;
			_mp.Volume = _previousVolume = 50;
			_mp.EndReached += _mp_EndReached;
			KeyPreview = true;
			KeyDown += new KeyEventHandler(ShortcutEvent);
		}
		
		//Event handler for various shortcuts
		public void ShortcutEvent(object sender, KeyEventArgs e)
		{
			Keys[] keys = {Keys.Escape, Keys.F, Keys.F12, Keys.M, Keys.Right, Keys.Left, Keys.Space };
			if(!keys.Contains(e.KeyCode))
				return;
			
			if (e.KeyCode == Keys.Escape && _isFullScreen) // from fullscreen to window
			{
				ExitFullScreen();
				return;
			}

			if (e.KeyCode == Keys.F || e.KeyCode == Keys.F12)
			{
				if (_isFullScreen)
					ExitFullScreen();
				else
					GoFullScreen();
				return;
			}

			if (e.KeyCode == Keys.M)
			{
				VolumeOnOffButton_Click(sender, e);
				return;
			}

			if (IsMediaSelected())
			{
				if (e.KeyCode == Keys.Space) // Pause and Play
				{
					if (_mp.State == VLCState.Playing) // if is playing
						Pause();
					else // it's not playing?
						Play(); // play
					return;
				}
				float TenSecInPercentage = 10000f / _mp.Length;

				if (e.KeyCode == Keys.Left) // skip 10sec backwards
				{
					if (_mp.Position >= TenSecInPercentage)
						_mp.Position -= TenSecInPercentage;
					else
						_mp.Position = 0;
				}

				if (e.KeyCode == Keys.Right) // skip 10sec forwards
				{
					if (_mp.Position <= 1 - TenSecInPercentage)
						_mp.Position += TenSecInPercentage;
					else
						_mp.Position = 1;
				}
			}
		}

		// Make player fullscreen
		private void GoFullScreen()
		{
			menuStrip1.Visible = false; // goodbye menu strip
			videoView1.Location = new Point(0, 0); // remove the offset
			FormBorderStyle = FormBorderStyle.None; // change form style
			WindowState = FormWindowState.Maximized;
			videoView1.Size = Size; // make video the same size as the form
			_isFullScreen = true;
		}

		// Make player exit fullscreen
		private void ExitFullScreen()
		{
			FormBorderStyle = FormBorderStyle.Sizable; // change form style
			WindowState = FormWindowState.Normal; // back to normal size
			Size = _oldFormSize;
			menuStrip1.Visible = true; // the return of the menu strip 
			videoView1.Size = _oldVideoSize; // make video the same size as the form
			videoView1.Location = _oldVideoLocation; // remove the offset
			_isFullScreen = false;
		}

		// Event handler for reaching the end of the media
		private void _mp_EndReached(object? sender, EventArgs e)
		{
			ThreadPool.QueueUserWorkItem(_ => _mp.Stop());
			this.InvokeEx(f => f.Reset());
		}

		private void PlayPauseButton_Click(object sender, EventArgs e)
		{
			if (!IsMediaSelected())
				return;

			if (!_mp.IsPlaying)
			{
				Play();
				return;
			}
			Pause();
		}

		private void Pause()
		{
			_mp.Pause();
			PlayPauseButton.Image = Resources.play;
			timer1.Stop();
		}

		private void Play()
		{
			_mp.Play();
			PlayPauseButton.Image = Resources.pause;
			timer1.Start();
		}

		private bool IsMediaSelected()
		{
			if (_media == null)
			{
				MessageBox.Show("Please select a mediafile!", "Error", MessageBoxButtons.OK);
				return false;
			}
			return true;
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			if (!IsMediaSelected())
				return;

			Stop();
		}

		private void Stop()
		{
			_mp.Stop();
			Reset();
		}

		private void Reset()
		{
			PlayPauseButton.Image = Resources.play;
			timer1.Stop();
			progressBar1.Value = 0;
			TimeElapsed.Text = "00:00";
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			if (VolumeBar.Value == 0)
				VolumeOnOffButton.Image = Resources.soundOff;
			else
				VolumeOnOffButton.Image = Resources.soundOn;

			SetVolumeAsVolumeBarValue();
		}

		private void SetVolumeAsVolumeBarValue()
		{
			_mp.Volume = VolumeBar.Value;
			_previousVolume = _mp.Volume;
			VolumePercentage.Text = VolumeBar.Value.ToString() + "%";
		}

		private void VolumeOnOffButton_Click(object sender, EventArgs e)
		{
			if (_mp.Volume != 0)
			{
				_previousVolume = _mp.Volume;
				_mp.Volume = 0;
				VolumeBar.Value = 0;
				VolumeOnOffButton.Image = Resources.soundOff;
			}
			else
			{
				_mp.Volume = _previousVolume;
				VolumeBar.Value = _previousVolume;
				VolumeOnOffButton.Image = Resources.soundOn;
			}
			VolumePercentage.Text = VolumeBar.Value.ToString() + "%";
		}

		private void CloseApp_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_mp.IsPlaying)
				Pause();

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				_media = new Media(_libVLC, ofd.FileName, FromType.FromPath);
				Reset();
			}
			else
			{
				if (_mp.State == VLCState.Paused)
					Play();
				return;
			}

			_mp.Media = _media;
			_mp.Media.AddOption(":start-paused");
			_mp.Play();
			Thread.Sleep(100);
			_mp.Media.AddOption(":no-start-paused");

			TimeSpan duration = new TimeSpan(_mp.Media.Duration * 10000);
			if (duration.Hours != 0)
				MediaDuration.Text = $"{duration.Hours:00}:{duration.Minutes:00}:{duration.Seconds:00}";
			else
				MediaDuration.Text = $"{duration.Minutes:00}:{duration.Seconds:00}";

			progressBar1.Maximum = (int)duration.TotalSeconds;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			TimeSpan timerPosition = new TimeSpan((long)(_mp.Position * _mp.Media.Duration * 10000));

			if (timerPosition.Hours != 0)
				TimeElapsed.Text = $"{timerPosition.Hours:00}:{timerPosition.Minutes:00}:{timerPosition.Seconds:00}";
			else
				TimeElapsed.Text = $"{timerPosition.Minutes:00}:{timerPosition.Seconds:00}";

			if (_mp.IsPlaying)
				progressBar1.Value = (int)timerPosition.TotalSeconds;
		}

		private void progressBar1_Click(object sender, EventArgs e)
		{
			if (!IsMediaSelected())
				return;

			float absoluteMouse = (PointToClient(MousePosition).X - progressBar1.Bounds.X);
			float calcFactor = progressBar1.Width / (float)progressBar1.Maximum;
			float relativeMouse = absoluteMouse / calcFactor;

			progressBar1.Value = Convert.ToInt32(relativeMouse);

			TimeSpan selectedTime = new TimeSpan((long)progressBar1.Value * 10000000);

			if (selectedTime.Hours != 0)
				TimeElapsed.Text = $"{selectedTime.Hours:00}:{selectedTime.Minutes:00}:{selectedTime.Seconds:00}";
			else
				TimeElapsed.Text = $"{selectedTime.Minutes:00}:{selectedTime.Seconds:00}";

			_mp.Position = (float)(selectedTime.TotalSeconds / (float)(_mp.Length / 1000));
		}

		private void VolumeBar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
			{
				e.SuppressKeyPress = true;
				return;
			}

			if (e.KeyCode == Keys.Up)
			{
				e.SuppressKeyPress = true;
				VolumeBar.Value += 1;
			}

			if (e.KeyCode == Keys.Down)
			{
				e.SuppressKeyPress = true;
				VolumeBar.Value -= 1;
			}
			SetVolumeAsVolumeBarValue();
		}

		private void addSubtitlesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!IsMediaSelected())
				return;

			if (_mp.IsPlaying)
				Pause();

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "All Subtitle Files|*.vtt;*.srt";

			if (ofd.ShowDialog() == DialogResult.OK)
				_mp.AddSlave(MediaSlaveType.Subtitle, "file:///" + ofd.FileName, true);
			else
			{
				if (_mp.State == VLCState.Paused)
					Play();
				return;
			}
		}
	}
}