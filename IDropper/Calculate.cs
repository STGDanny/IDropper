/*
*	FILE			=>	Calculate.cs
*	PROJECT			=>	IDropper
*	PROGRAMMER		=>	Daniel Pieczewski
*	LAST UPDATE		=>	2021-04-07
*	DESCRIPTION		=>
*		The methods(s) in this file make up the calculation logic for finding the colour of a given pixel on the screen.
*/

using System.Drawing;

namespace IDropper {
	internal class Calculate {
		/*
		*	METHOD			=>	GetColourAtPixel
		*	DESCRIPTION		=>
		*		This method takes a point on the screen and returns the colour of that pixel.
		*
		*	PARAMETERS		=>
		*		Point point	=>	Point to find the colour of.
		*
		*	RETURNS			=>
		*		Color		=>	Colour of the pixel passed as a parameter
		*/
		internal static Color GetColourAtPixel(Point point) {
			//Create a bitmap to store the pixel in
			var bmp = new Bitmap(1, 1);

			//Create a new graphics object with the bitmap:
			var g = Graphics.FromImage(bmp);

			//Copy the selected pixel into the graphics:
			g.CopyFromScreen(point, Point.Empty, new Size(point));

			//Return the only pixel in the bitmap => Our pixel colour:
			return bmp.GetPixel(0, 0);
		}
	}
}