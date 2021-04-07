using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace IDropper {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		public MainWindow() {
			InitializeComponent();
		}

		private static System.Drawing.Color GetColourAtPixel(int x, int y) {
			var bmp = new Bitmap(1, 1);
			var bounds = new System.Drawing.Point(x, y);

			var g = Graphics.FromImage(bmp);

			g.CopyFromScreen(bounds, System.Drawing.Point.Empty, new System.Drawing.Size(bounds));

			return bmp.GetPixel(0, 0);
		}

		private void Window_KeyDown(object sender, KeyEventArgs e) {
			if (e.Key == Key.Escape) {
				Close();
			}
		}

		private void Dropper_Click(object sender, EventArgs e) {
			Mouse.Capture(this);
			var selectedPixel = PointToScreen(Mouse.GetPosition(this));
			Mouse.Capture(null);

			System.Drawing.Color pixelColor = GetColourAtPixel((int)selectedPixel.X, (int)selectedPixel.Y);
			var rw = new ResultsWindow(pixelColor);
			rw.Show();
			Close();
		}
	}
}
