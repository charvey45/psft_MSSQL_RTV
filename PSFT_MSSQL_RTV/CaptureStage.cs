using System;
using System.Collections.Generic;
using System.Text;

namespace PSFT_MSSQL_RTV
{
	public sealed class CaptureStage
	{
		private static CaptureStage instance = null;
		private static CaptureStates _state = CaptureStates.Manual;
		private CaptureStage() { }

		public static CaptureStage Instance
		{
			get
			{
				if (instance == null)
				{ 
					instance = new CaptureStage(); 
					
				}
				return instance;
			}

		}

		public CaptureStates State { get; set; }
		public bool isAuto()
		{
			return (_state == CaptureStates.Auto) ? true : false;
		}

	}

}
