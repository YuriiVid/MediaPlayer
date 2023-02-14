using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
	internal static class ISynchronizeInvokeExtensions
	{
		public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
		{
			if (@this.InvokeRequired)
			{
				@this.Invoke(action, new object[] { @this });
			}
			else
			{
				action(@this);
			}
		}
	}
}
