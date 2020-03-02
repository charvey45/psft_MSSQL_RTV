using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
namespace PSFT_MSSQL_RTV
{
	class CaptureController
	{
		Timer AutoCaptuerTimer;

		CaptureController()
		{
			AutoCaptuerTimer = new Timer();
			AutoCaptuerTimer.Elapsed += OnTimedEvent; 
		}
		public void Capture() { 
		}

		private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
		{
			Capture();
		}
	}
}
