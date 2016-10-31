using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.Controls
{
    public partial class LabelWithBorder : Label
    {
        #region Fields
        private Label Cover;
        #endregion

		#region Properties
        private bool blank;
        [Description("Field is blank")]
        public bool Blank
        {
            get
            {
                return blank;
            }
            set
            {
                blank = value;
                Invalidate();
            }
        }

        private bool border;
        [Description("Field is border")]
        public bool Border
        {
            get
            {
                return border;
            }
            set 
            {
                border = value;
                Invalidate();
            }
        }


		#endregion

		#region Constructor 
            
        public LabelWithBorder()
            : base()
			{
            Cover = new Label();
			Cover.ForeColor = Color.Gray;
            Cover.BackColor = Color.Gray;
			Cover.AutoSize = false;
			}
		#endregion

		#region Event Handlers
		protected override void OnPaint(PaintEventArgs e)
			{
                Cover.Size = new Size(this.Size.Width - 4, this.Size.Height - 4);
                Cover.Location = new Point(this.Location.X + 2, this.Location.Y + 2);
                if (blank)
                {
                    Parent.Controls.Add(Cover);
                    Cover.BringToFront();
                }
                else
                    Parent.Controls.Remove(Cover);

            base.OnPaint(e);
            if(border)
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Gold, ButtonBorderStyle.Solid);

            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
            }
			
			}

		#endregion
    }
}
