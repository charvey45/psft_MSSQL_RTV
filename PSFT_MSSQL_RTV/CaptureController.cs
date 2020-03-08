using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
namespace PSFT_MSSQL_RTV
{
	public class CaptureController
	{
		Timer AutoCaptuerTimer;

		public CaptureController()
		{
			AutoCaptuerTimer = new Timer();
			AutoCaptuerTimer.Elapsed += OnTimedEvent; 
		}
		public void Capture() { 
		}

		private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
		{
			throw new NotImplementedException();
		}

		internal void AutoCapture(bool v)
		{
			throw new NotImplementedException();
		}
	}
}
