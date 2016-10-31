using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.Screens;
using DDOCharacterPlanner.SaveDataModel;


namespace DDOCharacterPlanner.Utility
    {
    public static class UtilityClass
        {
		#region Shared Members
        /// <summary>
        /// Wrap the description with some html tags to be used in the HTMLEditor control
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string BuildHTMLDescripton(string description)
            {
			UIManagerClass uiManager = UIManagerClass.UIManager;
			string fullDescription = "";
            
            //Add the html and body tags
            fullDescription = "<html><style>body {background-color: ";
//			fullDescription += ColorTranslator.ToHtml(uiManager.Skin.BackgroundColor);
            fullDescription += "; color: ";
//			fullDescription += ColorTranslator.ToHtml(uiManager.Skin.StandardFontColor);
            fullDescription += ";}</style><body contentEditable='true'>";
            //now lets add in our actual description
            fullDescription += description;
            //now to add the closing body and html tags
            fullDescription += "</body></html>";
            
            return fullDescription;
            }

        /// <summary>
        /// Will remove some un-necessary tags that the HTMLEditor placed that isn't needed in our database
        /// This should be called before sending the description to the model for database manipulation.
        /// </summary>
        /// <param name="htmldescription"></param>
        /// <returns></returns>
        public static string RemoveHTMLFromDescription(string htmldescription)
            {
			UIManagerClass uiManager = UIManagerClass.UIManager;
			string newDescription = "";
            string headerToRemove;
            string footerToRemove;

            newDescription = htmldescription;

			//headerToRemove = "<P><FONT style=\"BACKGROUND-COLOR: " + ColorTranslator.ToHtml(uiManager.Skin.BackgroundColor).ToLower() + "\">";
            footerToRemove = "</FONT></P>";

//            newDescription = newDescription.Replace(headerToRemove, "");
            newDescription = newDescription.Replace(footerToRemove, "");
           
            return newDescription;
            }

        /// <summary>
        /// Temporary method to strip out HTML Tags for our description fields
        /// We can delete this once it is no longer needed.
        /// </summary>
        /// <param name="oldDescription"></param>
        /// <returns></returns>
        public static string StripHTMLfromOldDescriptions(string oldDescription)
            {
            string newDescription = "";
            string headerToRemove = "<HTML><body style=\"background: #000000\"><font color=\"white\">";
            string footerToRemove = "</font></body></HTML>";

            newDescription = oldDescription.Replace(headerToRemove, "");
            newDescription = newDescription.Replace(footerToRemove, "");

            return newDescription;
            }
        /// <summary>
        /// Temporary method to strip our current feat Description of the HTML tags that are no longer needed.
        /// </summary>
        public static void FixFeatDescriptions()
            {
            int count;
            FeatModel model;
            List<string> featNames;
            string newDescription;

            featNames = FeatModel.GetNames();
            count = featNames.Count();
            //count = 1;
            for (int i = 0; i < count; i++)
                {
                model = new FeatModel();
                model.Initialize(featNames[i]);
                if (model.Description != null)
                    {
                    newDescription = StripHTMLfromOldDescriptions(model.Description);
                    model.Description = newDescription;
                    model.Save();
                    }
                }
            }

		public static string AddNewLinesForTooltip(string text, int maximumLength=20)
			{
			int lineLength;
			StringBuilder sb;
			int currentLinePosition;

			//strip any existing newlines
			text = text.Replace(Environment.NewLine, " ");

			if (text.Length < maximumLength)
				return text;
			lineLength = (int)Math.Sqrt((double)text.Length) * 2;
			sb = new StringBuilder();
			currentLinePosition = 0;
			for (int textIndex = 0; textIndex < text.Length; textIndex++)
				{
				// If we have reached the target line length and the next 
				// character is whitespace then begin a new line.
				if (currentLinePosition >= lineLength && char.IsWhiteSpace(text[textIndex]))
					{
					sb.Append(Environment.NewLine);
					currentLinePosition = 0;
					}
				// If we have just started a new line, skip all the whitespace.
				if (currentLinePosition == 0)
					while (textIndex < text.Length && char.IsWhiteSpace(text[textIndex]))
						textIndex++;
				// Append the next character.
				if (textIndex < text.Length)
					sb.Append(text[textIndex]);

				currentLinePosition++;
				}
			return sb.ToString();
			}

        /// <summary>
        /// Return a index list of the sorted list value
        /// </summary>
        /// <param name="listToBeSorted">this is a list of int that you need sorted</param>
        /// <returns>return the sorted index of the list you provided, this doesn't return a sorted list of values</returns>
        public static List<int> ReturnSortedIndex(List<int> listToBeSorted)
            {
            List<int> sortedIndexList;
            List<int> sortedList;
            int index;
            int lastIndex;

            sortedIndexList = new List<int>();
            sortedList = new List<int>();

            sortedList = listToBeSorted.OrderByDescending(listtobesorted => listtobesorted).ToList();
            lastIndex = -1;
            for (int x = 0; x < sortedList.Count; x++)
                {
                index = listToBeSorted.IndexOf(sortedList[x]);
                if (index == lastIndex)
                    index = listToBeSorted.IndexOf(sortedList[x], lastIndex +1);
                sortedIndexList.Add(index);
                lastIndex = index;
                }

            return sortedIndexList;
            }

        public static Image ConvertImageToGrayscale(Image image)
            {
            Bitmap grayscaleImage;
            Bitmap colorImage;
            int width;
            int height;
            Color color;
            byte colorMono;
            colorImage = (Bitmap)image;

            width = colorImage.Width;
            height = colorImage.Height;

            grayscaleImage = new Bitmap(width, height);

            for (int i=0; i<height; i++)
                for (int J = 0; J < width; J++)
                    {
                    color = colorImage.GetPixel(J, i);
                    colorMono = (byte)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                    grayscaleImage.SetPixel(J, i, Color.FromArgb(color.A, colorMono, colorMono, colorMono));
                    }

            return grayscaleImage;
            }
		#endregion
        }
    }
