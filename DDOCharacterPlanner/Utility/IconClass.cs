using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Utility
    {
    public class IconClass
        {
        #region Member Variables
        private bool IsLoaded;
        private string FileName;
		private Bitmap ColorImage;
		private Bitmap MonoImage;
		PointF Location;
		PointF Size;
		#endregion

		#region Constructors
		public IconClass()
			{
			FileName = "NoImage";
			IsLoaded = false;
			Location = new PointF(0.0f, 0.0f);
			Size = new PointF(0.0f, 0.0f);
			}

		public IconClass(string fileName)
			{
			FileName = fileName;
			IsLoaded = false;
			Location = new PointF(0.0f, 0.0f);
			Size = new PointF(0.0f, 0.0f);
			}
		#endregion

		#region Public Methods
		public void Draw(PaintEventArgs paintEvent)
            {
			if (!IsLoaded)
                {
                if (!Load())
					return;
                }

			// Draw image to screen.
			paintEvent.Graphics.DrawImage(ColorImage, Location);
			//store the size for the OnClick routine
			Size.X = ColorImage.Width;
			Size.Y = ColorImage.Height;
	        }

		public void Draw(PaintEventArgs paintEvent, float scaleX, float scaleY)
			{
			if (!IsLoaded)
				{
				if (!Load())
					return;
				}

			// Draw image to screen.
			paintEvent.Graphics.DrawImage(ColorImage, Location.X, Location.Y, ColorImage.Width * scaleX, ColorImage.Height * scaleY);
			//store the size for the OnClick routine
			Size.X = ColorImage.Width * scaleX;
			Size.Y = ColorImage.Height * scaleY;
			}

		public void Draw(PaintEventArgs paintEvent, int scaleX, int scaleY)
			{
			if (!IsLoaded)
				{
				if (!Load())
					return;
				}

			// Draw image to screen.
			paintEvent.Graphics.DrawImage(ColorImage, Location.X, Location.Y, scaleX, scaleY);
			//store the size for the OnClick routine
			Size.X = scaleX;
			Size.Y = scaleY;
			}

		public void DrawMonochrome(PaintEventArgs paintEvent)
            {
            if (!IsLoaded)
                {
                if (!Load())
					return;
                }
			paintEvent.Graphics.DrawImage(MonoImage, Location);
			Size.X = ColorImage.Width;
			Size.Y = ColorImage.Height;
			}

		public void DrawMonochrome(PaintEventArgs paintEvent, float scaleX, float scaleY)
			{
			if (!IsLoaded)
				{
				if (!Load())
					return;
				//store the size for the OnClick routine
				Size.X = ColorImage.Width * scaleX;
				Size.Y = ColorImage.Height * scaleY;
				}

			// Draw image to screen.
			paintEvent.Graphics.DrawImage(MonoImage, Location.X, Location.Y, ColorImage.Width * scaleX, ColorImage.Height * scaleY);
			}

		public void DrawMonochrome(PaintEventArgs paintEvent, int scaleX, int scaleY)
			{
			if (!IsLoaded)
				{
				if (!Load())
					return;
				}

			// Draw image to screen.
			paintEvent.Graphics.DrawImage(MonoImage, Location.X, Location.Y, scaleX, scaleY);
			//store the size for the OnClick routine
			Size.X = scaleX;
			Size.Y = scaleY;
			}

		/// <summary>
		/// Set the location of the icon
		/// </summary>
		/// <param name="Width">Width of the screen</param>
		/// <param name="Height">Height of the screen</param>
		/// <param name="newLocation">Location of the icon (normalized to 0->1)</param>
		public void SetLocation(int Width, int Height, PointF newLocation)
			{
			Location = new PointF(Width*newLocation.X, Height*newLocation.Y);
			}


		/// <summary>
		/// returns true if the given coordinates are over the icon
		/// </summary>
		/// <param name="x">Window Coordinate X</param>
		/// <param name="y">Window Coordinate Y</param>
		/// <returns></returns>
		public bool IsOver(int x, int y)
			{
			//note that the current location depends on how the icon was drawn (scaled or not scaled)
			if (x >= Location.X && x<= Location.X + Size.X)
				{
				if (y >= Location.Y && y <= Location.Y + Size.Y)
					{
					//Debug.WriteLine("Location: " + Location.X + "," + Location.Y + " to " + (Location.X + Size.X) + "," + (Location.Y + Size.Y));
					return true;
					}
				}
			return false;
			}
		#endregion

        #region Private Methods
        private bool Load()
            {
			Image img;
			int width;
			int height;
			Color color;
			byte colorMono;

			try
				{
				img = Image.FromFile(Application.StartupPath + "\\Graphics\\" + FileName + ".png");
				ColorImage = new Bitmap(img);
				}
			catch (FileNotFoundException)
				{
				// file not found, instead load the NoImage png file
                Debug.WriteLine("Warning: Image not found: " + FileName + ". Instead loading NoImage.png file.");
                try
					{
					img = Image.FromFile(Application.StartupPath + "\\Graphics\\NoImage.png");
					ColorImage = new Bitmap(img);
					}
				catch (FileNotFoundException)
					{
					// uh oh, we can't even find the NoImage.png file! Now we are seriously in trouble!
					Debug.WriteLine("Critical Error: Unable to load Image: " + FileName);
					return false;
					}
				}

			//create the monochrome image
			width = ColorImage.Width;
			height = ColorImage.Height;

			MonoImage = new Bitmap(width, height);
			for (int i = 0; i<height; i++)
				for (int j = 0; j<width; j++)
					{
					color = ColorImage.GetPixel(j, i);
					colorMono = (byte)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
					MonoImage.SetPixel(j, i, Color.FromArgb(color.A, colorMono, colorMono, colorMono));
					}

			IsLoaded = true;

			return true;
            }
		#endregion
        }
    }


