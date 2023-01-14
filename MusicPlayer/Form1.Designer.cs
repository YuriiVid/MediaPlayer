
namespace MusicPlayer
{
	partial class MusicPlayerApp
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.PlayPauseButton = new System.Windows.Forms.PictureBox();
			this.StopButton = new System.Windows.Forms.PictureBox();
			this.VolumeBar = new System.Windows.Forms.TrackBar();
			this.VolumePercentage = new System.Windows.Forms.Label();
			this.VolumeOnOffButton = new System.Windows.Forms.PictureBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.TimeElapsed = new System.Windows.Forms.Label();
			this.MediaDuration = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.videoView1 = new LibVLCSharp.WinForms.VideoView();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.addSubtitlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.PlayPauseButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StopButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.VolumeOnOffButton)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.videoView1)).BeginInit();
			this.SuspendLayout();
			// 
			// PlayPauseButton
			// 
			this.PlayPauseButton.BackColor = System.Drawing.SystemColors.Control;
			this.PlayPauseButton.Image = global::MusicPlayer.Properties.Resources.play;
			this.PlayPauseButton.InitialImage = global::MusicPlayer.Properties.Resources.play;
			this.PlayPauseButton.Location = new System.Drawing.Point(289, 351);
			this.PlayPauseButton.Name = "PlayPauseButton";
			this.PlayPauseButton.Size = new System.Drawing.Size(40, 40);
			this.PlayPauseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PlayPauseButton.TabIndex = 3;
			this.PlayPauseButton.TabStop = false;
			this.PlayPauseButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
			// 
			// StopButton
			// 
			this.StopButton.Image = global::MusicPlayer.Properties.Resources.stop_74;
			this.StopButton.Location = new System.Drawing.Point(335, 351);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(40, 40);
			this.StopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.StopButton.TabIndex = 4;
			this.StopButton.TabStop = false;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// VolumeBar
			// 
			this.VolumeBar.Location = new System.Drawing.Point(525, 355);
			this.VolumeBar.Maximum = 100;
			this.VolumeBar.Name = "VolumeBar";
			this.VolumeBar.Size = new System.Drawing.Size(161, 56);
			this.VolumeBar.TabIndex = 0;
			this.VolumeBar.TabStop = false;
			this.VolumeBar.Value = 50;
			this.VolumeBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			this.VolumeBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VolumeBar_KeyDown);
			// 
			// VolumePercentage
			// 
			this.VolumePercentage.AutoSize = true;
			this.VolumePercentage.Location = new System.Drawing.Point(680, 357);
			this.VolumePercentage.Name = "VolumePercentage";
			this.VolumePercentage.Size = new System.Drawing.Size(37, 20);
			this.VolumePercentage.TabIndex = 6;
			this.VolumePercentage.Text = "50%";
			// 
			// VolumeOnOffButton
			// 
			this.VolumeOnOffButton.Image = global::MusicPlayer.Properties.Resources.soundOn;
			this.VolumeOnOffButton.Location = new System.Drawing.Point(479, 351);
			this.VolumeOnOffButton.Name = "VolumeOnOffButton";
			this.VolumeOnOffButton.Size = new System.Drawing.Size(40, 40);
			this.VolumeOnOffButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.VolumeOnOffButton.TabIndex = 7;
			this.VolumeOnOffButton.TabStop = false;
			this.VolumeOnOffButton.Click += new System.EventHandler(this.VolumeOnOffButton_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(7, 339);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(779, 10);
			this.progressBar1.TabIndex = 8;
			this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
			// 
			// TimeElapsed
			// 
			this.TimeElapsed.AutoSize = true;
			this.TimeElapsed.Location = new System.Drawing.Point(7, 352);
			this.TimeElapsed.Name = "TimeElapsed";
			this.TimeElapsed.Size = new System.Drawing.Size(44, 20);
			this.TimeElapsed.TabIndex = 9;
			this.TimeElapsed.Text = "00:00";
			// 
			// MediaDuration
			// 
			this.MediaDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MediaDuration.AutoSize = true;
			this.MediaDuration.Location = new System.Drawing.Point(746, 352);
			this.MediaDuration.Name = "MediaDuration";
			this.MediaDuration.Size = new System.Drawing.Size(44, 20);
			this.MediaDuration.TabIndex = 10;
			this.MediaDuration.Text = "00:00";
			this.MediaDuration.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.playlistToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 28);
			this.menuStrip1.TabIndex = 11;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.addSubtitlesToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// playlistToolStripMenuItem
			// 
			this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
			this.playlistToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
			this.playlistToolStripMenuItem.Text = "Playlist";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// videoView1
			// 
			this.videoView1.BackColor = System.Drawing.Color.Black;
			this.videoView1.Location = new System.Drawing.Point(12, 42);
			this.videoView1.MediaPlayer = null;
			this.videoView1.Name = "videoView1";
			this.videoView1.Size = new System.Drawing.Size(774, 293);
			this.videoView1.TabIndex = 12;
			this.videoView1.Text = "videoView1";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// addSubtitlesToolStripMenuItem
			// 
			this.addSubtitlesToolStripMenuItem.Name = "addSubtitlesToolStripMenuItem";
			this.addSubtitlesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.addSubtitlesToolStripMenuItem.Text = "Add Subtitles";
			this.addSubtitlesToolStripMenuItem.Click += new System.EventHandler(this.addSubtitlesToolStripMenuItem_Click);
			// 
			// MusicPlayerApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.videoView1);
			this.Controls.Add(this.MediaDuration);
			this.Controls.Add(this.TimeElapsed);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.VolumeOnOffButton);
			this.Controls.Add(this.VolumePercentage);
			this.Controls.Add(this.VolumeBar);
			this.Controls.Add(this.StopButton);
			this.Controls.Add(this.PlayPauseButton);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MusicPlayerApp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MusicPlayerApp";
			((System.ComponentModel.ISupportInitialize)(this.PlayPauseButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StopButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.VolumeOnOffButton)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.videoView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private PictureBox PlayPauseButton;
		private PictureBox StopButton;
		private TrackBar VolumeBar;
		private Label VolumePercentage;
		private PictureBox VolumeOnOffButton;
		private ProgressBar progressBar1;
		private Label TimeElapsed;
		private Label MediaDuration;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem playlistToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private ToolStripMenuItem openToolStripMenuItem;
		private LibVLCSharp.WinForms.VideoView videoView1;
		private System.Windows.Forms.Timer timer1;
		private ToolStripMenuItem addSubtitlesToolStripMenuItem;
	}
}