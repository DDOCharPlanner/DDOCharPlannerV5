using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DDOCharacterPlanner.Utility
	{
	public class SkinStyleClass
		{
		#region Properties
		public Font Font
			{
			get;
			set;
			}
		public Color Color1
			{
			get;
			set;
			}
		public Color Color2
			{
			get;
			set;
			}
		#endregion

		#region Constructors
		//full constructor, manually determine all parameters (can be used for buttons)
		public SkinStyleClass(string fontName, float fontSize, FontStyle style, Color foreColor, Color backColor)
			{
			Font = new Font(fontName, fontSize, style);
			Color1 = foreColor;
			Color2 = backColor;
			}

		//used for standard fonts (no styles) with tranparent backgrounds
		public SkinStyleClass(string fontName, float fontSize, Color fontColor)
			{
			FontStyle style;

			style = 0;
			Font = new Font(fontName, fontSize, style);
			Color1 = fontColor;
			Color2 = Color.FromName("Tranparent");
			}

		//used for non-standard fonts (various styles) with tranparent backgrounds
		public SkinStyleClass(string fontName, float fontSize, FontStyle style, Color fontColor)
			{
			Font = new Font(fontName, fontSize, style);
			Color1 = fontColor;
			Color2 = Color.FromName("Tranparent");
			}

		//used for one color items (such as background colors for screens and panels)
		public SkinStyleClass(Color color)
			{
			Color1 = color;
			}

		#endregion
		}
	}
