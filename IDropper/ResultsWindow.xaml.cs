/*
*	FILE			=>	ResultsWindow.xaml.cs
*	PROJECT			=>	IDropper
*	PROGRAMMER		=>	Daniel Pieczewski
*	LAST UPDATE		=>	2021-04-07
*	DESCRIPTION		=>
*		The methods(s) in this file make up the interaction logic for the ResultsWindow. They handle any events
*		related to the ResultsWindow.
*/

//Import Usings:
using System.Windows;
using System.Windows.Media;

//Convenience Usings:
using Color = System.Drawing.Color;

namespace IDropper {
	public partial class ResultsWindow : Window {
		/*
		*	METHOD			=>	ResultsWindow
		*	DESCRIPTION		=>
		*		This method is the constructor for the ResultsWindow class
		*
		*	PARAMETERS		=>
		*		Color point	=>	Colour of the pixel to display the properties of.
		*/
		public ResultsWindow(Color pixelColor) {
			InitializeComponent();

			//Generate the data required:
			DisplayData(pixelColor);
		}

		/*
		*	METHOD					=>	DisplayData
		*	DESCRIPTION				=>
		*		This method takes a colour and displays it's properties in various formats.
		*
		*	PARAMETERS				=>
		*		Color pixelColor	=>	Colour to display the properties of.
		*
		*	RETURNS					=>
		*		void				=>	void
		*/
		private void DisplayData(Color pixelColor) {
			//Create a new string containing the hex values for the pixel colour:s
			var hexString = $"{pixelColor.R:X2}{pixelColor.G:X2}{pixelColor.B:X2}";

			//Create a new fill colour from the drawing color:
			var fillColour = System.Windows.Media.Color.FromArgb(pixelColor.A, pixelColor.R, pixelColor.G, pixelColor.B);

			//Fill the colour display with the colour:
			ColourDisplay.Fill = new SolidColorBrush(fillColour);

			//Fill the text boxes with the information:
			RValue.Text = $"R: {pixelColor.R}";
			GValue.Text = $"G: {pixelColor.G}";
			BValue.Text = $"B: {pixelColor.B}";
			HexValue.Text = $"Hex: #{hexString}";
		}

		/*
		*	METHOD					=>	NewColourButton_Click
		*	DESCRIPTION				=>
		*		This method is an event handler for the click event on the new colour button.
		*		It re-opens the eye dropper MainWindow.
		*
		*	PARAMETERS				=>
		*		object sender		=>	Sender of the event.
		*		RoutedEventArgs e	=>	Any event args sent from the sender.
		*
		*	RETURNS					=>
		*		void				=>	void
		*/
		private void NewColourButton_Click(object sender, RoutedEventArgs e) {
			//Create new MainWindow to go again:
			new EyeDropperWindow().Show();

			//Close the results window:
			Close();
		}
	}
}