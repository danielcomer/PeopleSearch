using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Jti.EcourtWordAddIn.UI.Controls
{
	/// <summary>
	/// Interaction logic for CircularProgressBar.xaml
	/// </summary>
	public partial class CircularProgressBar : UserControl
	{
		static CircularProgressBar()
		{
			Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(CircularProgressBar), new FrameworkPropertyMetadata(30));
		}

		public CircularProgressBar()
		{
			InitializeComponent();
		}
	}
}
