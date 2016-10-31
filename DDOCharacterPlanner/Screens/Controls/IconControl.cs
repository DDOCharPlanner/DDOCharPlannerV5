using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Screens.Controls
    {
    public partial class IconControl : UserControl
        {
        #region Enums
        public enum ICType 
            {
            Active,
            Passive,
            };

        #endregion

        #region Member Variables
        private ICType ControlType;
        private bool IconSelected;
        private bool IconAvailable;

        //Graphic Locations
        private PointF IconLocation = new PointF(.13f, .14f);
        private PointF IconBorderLocation = new PointF(.11f, .12f);
        private PointF IconSelectedLocation = new PointF(.00f, .00f);
        private PointF IconNotSelectableLocation = new PointF(.15f, .16f);

        //Graphics
        private IconClass BaseIcon;
        private IconClass IconBorderActive;
        private IconClass IconBorderPassive;
        private IconClass IconSelectedActive;
        private IconClass IconSelectedPassive;
        private IconClass IconNotSelectableActive;
        private IconClass IconNotSelectablePassive;

        #endregion

        #region Properties
        [Category("_IconControl")]
        public ICType IconType
            {
            get { return ControlType; }
            set { ControlType = value; }
            }

        [Category("_IconControl")]
        public bool Selected
            {
            get { return IconSelected; }
            set { IconSelected = value;
            Invalidate();
            }
            }

        [Category("_IconControl")]
        public bool Availability
            {
            get { return IconAvailable; }
            set { IconAvailable = value; }
            }

        #endregion

        #region Contstructors
        public IconControl()
            {
            InitializeComponent();

            //setup the default graphics
            SetDefaultGraphics();
            }

        #endregion

        #region Events
        private void IconControl_Paint(object sender, PaintEventArgs e)
            {
            DrawIcon(e);
            }

        #endregion

        #region Private Methods
        private void DrawIcon(PaintEventArgs pe)
            {
            if (ControlType == ICType.Active)
                {
                //Icon
                BaseIcon.Draw(pe);
                //IconBorder
                IconBorderActive.Draw(pe);
                //Is the Icon Available to be selected
                if (IconAvailable == false)
                    IconNotSelectableActive.Draw(pe);
                //is the Icon Selected
                if (IconSelected == true)
                    IconSelectedActive.Draw(pe);
                }
            else
                {
                //Icon
                BaseIcon.Draw(pe);
                //IconBorder
                IconBorderPassive.Draw(pe);
                //Is the Icon Available to be selected
                if (IconAvailable == false)
                    IconNotSelectablePassive.Draw(pe);
                //is the Icon Selected
                if (IconSelected == true)
                    IconSelectedPassive.Draw(pe);
                }
            }

        private void SetDefaultGraphics()
            {
            BaseIcon = new IconClass("Interface\\IconEmptyPassive");
            BaseIcon.SetLocation(this.Width, this.Height, IconLocation);
            IconBorderActive = new IconClass("Interface\\IconBorderActive");
            IconBorderActive.SetLocation(this.Width, this.Height, IconBorderLocation);
            IconBorderPassive = new IconClass("Interface\\IconBorderPassive");
            IconBorderPassive.SetLocation(this.Width, this.Height, IconBorderLocation);
            IconSelectedActive = new IconClass("Interface\\IconSelectedActive");
            IconSelectedActive.SetLocation(this.Width, this.Height, IconSelectedLocation);
            IconSelectedPassive = new IconClass("Interface\\IconSelectedPassive");
            IconSelectedPassive.SetLocation(this.Width, this.Height, IconSelectedLocation);
            IconNotSelectableActive = new IconClass("Interface\\IconNotSelectableActive");
            IconNotSelectableActive.SetLocation(this.Width, this.Height, IconNotSelectableLocation);
            IconNotSelectablePassive = new IconClass("Interface\\IconNotSelectablePassive");
            IconNotSelectablePassive.SetLocation(this.Width, this.Height, IconNotSelectableLocation);
            }

        #endregion

        #region Public Methods
        public void Clear()
            {
            SetDefaultGraphics();
            }

        /// <summary>
        /// Use this to set IconControl Icon image
        /// when sending you need to send the subfolder like
        /// "Enhancements\\IconName".
        /// </summary>
        /// <param name="iconName"></param>
        public void SetIcon(string iconName)
            {
            BaseIcon = new IconClass(iconName);
            BaseIcon.SetLocation(this.Width, this.Height, IconLocation);
            Invalidate();
            }

        #endregion
        
        }
    }
