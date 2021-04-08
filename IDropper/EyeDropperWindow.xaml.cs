/*
*	FILE			=>	EyeDropperWindow.xaml.cs
*	PROJECT			=>	IDropper
*	PROGRAMMER		=>	Daniel Pieczewski
*	LAST UPDATE		=>	2021-04-07
*	DESCRIPTION		=>
*		The methods(s) in this file make up the interaction logic for the EyeDropperWindow. They handle any events
*		related to the EyeDropperWindow.
*/

//Import Usings:
using System;
using System.Windows;
using System.Windows.Input;

namespace IDropper {
	public partial class EyeDropperWindow : Window {
		/*
		*	METHOD		=>	EyeDropperWindow
		*	DESCRIPTION	=>
		*		This method is the constructor for the EyeDropperWindow class
		*
		*	PARAMETERS	=>
		*		void	=>	void
		*/
		public EyeDropperWindow() => InitializeComponent();

		/*
		*	METHOD				=>	Window_KeyDown
		*	DESCRIPTION			=>
		*		This method is an event handler for the KeyDown event on the window.
		*		It determines the action to take depending on the key pressed.
		*
		*	PARAMETERS			=>
		*		object sender	=>	Sender of the event.
		*		KeyEventArgs e	=>	Any event args sent from the sender.
		*
		*	RETURNS				=>
		*		void			=>	void
		*/
		private void Window_KeyDown(object sender, KeyEventArgs e) {
			//IF the key pressed is Escape => Exit the program:
			if (e.Key == Key.Escape) {
				Close();
			}

			//IF the key pressed is Enter => Activate the dropper:
			else if (e.Key == Key.Enter) {
				ActivateDropper();
			}
		}

		/*
		*	METHOD		=>	ActivateDropper
		*	DESCRIPTION	=>
		*		This method activated the eye dropper and captures the point to interpolate.
		*
		*	PARAMETERS	=>
		*		void	=>	void
		*
		*	RETURNS		=>
		*		void	=>	void
		*/
		private void ActivateDropper() {
			//Get the pixel under the mouse cursor:
			Mouse.Capture(this);
			Point selectedPixel = PointToScreen(Mouse.GetPosition(this));
			Mouse.Capture(null);

			//Create a new ResultsWindow and open it:
			new ResultsWindow(Calculate.GetColourAtPixel(new System.Drawing.Point((int)selectedPixel.X, (int)selectedPixel.Y))).Show();

			//Close the IDropper window:
			Close();
		}

		/*
		*	METHOD				=>	Window_KeyDown
		*	DESCRIPTION			=>
		*		This method is an event handler for the Deactivated event on the window.
		*		It changes the window border colour to Green to signify un-readiness to perform an eye dropper.
		*
		*	PARAMETERS			=>
		*		object sender	=>	Sender of the event.
		*		EventArgs e	=>	Any event args sent from the sender.
		*
		*	RETURNS				=>
		*		void			=>	void
		*/
		private void Window_Deactivated(object sender, EventArgs e) => Hitbox.Stroke = System.Windows.Media.Brushes.Lime;

		/*
		*	METHOD				=>	Window_Activated
		*	DESCRIPTION			=>
		*		This method is an event handler for the Activated event on the window.
		*		It changes the window border colour to Red to signify readiness to perform an eye dropper.
		*
		*	PARAMETERS			=>
		*		object sender	=>	Sender of the event.
		*		EventArgs e		=>	Any event args sent from the sender.
		*
		*	RETURNS				=>
		*		void			=>	void
		*/
		private void Window_Activated(object sender, EventArgs e) => Hitbox.Stroke = System.Windows.Media.Brushes.Red;
	}
}