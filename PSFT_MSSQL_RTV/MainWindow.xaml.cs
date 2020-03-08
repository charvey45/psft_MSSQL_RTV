using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PSFT_MSSQL_RTV
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		CaptureController Controller;
		public MainWindow()
		{
			InitializeComponent();
			CaptureStage StateHolder = CaptureStage.Instance;
			this.Controller = new CaptureController();
			StateHolder.State = CaptureStates.Manual;
		}

		private void CaptureNow_Click(object sender, RoutedEventArgs e)
		{
			CaptureStage StateHolder = CaptureStage.Instance;
			switch (StateHolder.State)
			{
				case CaptureStates.Manual:
					Capture();
					break;
				case CaptureStates.Auto:
					//Already Running Issue stop
					StopAutoCapture();
					break;
				case CaptureStates.Ready:
					//Auto Setup Complete ready to Begin
					StartAutoCaputer();
					break;
				case CaptureStates.Stopped:
					//Auto Setup Complete ready to contiue
					StartAutoCaputer();
					break;

			}
			
		}

		private void StartAutoCaputer()
		{
			this.Controller.AutoCapture(true);
		}

		private void StopAutoCapture()
		{
			this.Controller.AutoCapture(false);
		}

		private void Capture()
		{
			this.Controller.Capture();
		}

		private void AutoCaptureFrequencySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (this.AutoCaptureFrequencyText != null)
				this.AutoCaptureFrequencyText.Text = this.AutoCaptureFrequencySlider.Value.ToString();

		}

		private void AutoCaptureOption_Checked(object sender, RoutedEventArgs e)
		{
			this.CaptureNow.Content = "Begin Capture";
			SetAutoCapture(true, CaptureStates.Auto);
		}

		private void AutoCaptureOption_Unchecked(object sender, RoutedEventArgs e)
		{
			this.CaptureNow.Content = "Capture Now";
			SetAutoCapture(false, CaptureStates.Manual);
		}


		private void SetAutoCapture(bool isAuto, CaptureStates State)
		{
			this.AutoCaptureFrequencySlider.IsEnabled = isAuto;
			CaptureStage StateHolder = CaptureStage.Instance;
			StateHolder.State = State;

		}
	}
}
