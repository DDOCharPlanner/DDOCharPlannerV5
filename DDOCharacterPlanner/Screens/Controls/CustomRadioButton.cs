using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.Controls
{
    public class CustomRadioButton : RadioButton
    {
        #region Fields

        #endregion

        #region Properties 
        private Color _disabledColor;
        public Color disabledColor
        {
            get
            {
                return _disabledColor;
            }
            set
            {
                _disabledColor = value;
                Invalidate();
            }
        }
        #endregion
        #region Constructor
        public CustomRadioButton()
            : base()
        {
            disabledColor = Color.Gray;
        }
        #endregion
        #region Event Handlers
        protected override void OnPaint(PaintEventArgs e)
            {
                
                Rectangle myRectangle;
                myRectangle = ClientRectangle;
                myRectangle.X = 17;
                myRectangle.Y = (ClientRectangle.Height-Font.Height)/2;
                
                base.OnPaint(e);
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                if(base.Enabled)
                {   
                    e.Graphics.FillRectangle(new SolidBrush(base.BackColor), myRectangle);
                    e.Graphics.DrawString(Text, this.Font, new SolidBrush(ForeColor), myRectangle);
                    
                    return;
                }


                e.Graphics.FillRectangle(new SolidBrush(base.BackColor), myRectangle);
                e.Graphics.DrawString(Text, this.Font, new SolidBrush(disabledColor), myRectangle);
                
            }


        
        #endregion
    }
}
