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
using System.Windows.Shapes;

namespace IDropper {
	public partial class ResultsWindow : Window {

		public ResultsWindow(System.Drawing.Color pixelColor) {
			InitializeComponent();
			DisplayData(pixelColor);
		}

		private void DisplayData(System.Drawing.Color pixelColor) {
			string hexString = $"{pixelColor.R:X2}{pixelColor.G:X2}{pixelColor.B:X2}";

			ColourDisplay.Fill = new SolidColorBrush(Color.FromArgb(pixelColor.A, pixelColor.R, pixelColor.G, pixelColor.B));
			RValue.Text = $"R: {pixelColor.R}";
			GValue.Text = $"G: {pixelColor.G}";
			BValue.Text = $"B: {pixelColor.B}";
			HexValue.Text = $"Hex: #{hexString}";
		}

		private void NewColourButton_Click(object sender, RoutedEventArgs e) {
			var mw = new MainWindow();
			mw.Show();
			Close();
		}
	}
}
