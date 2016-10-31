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
    public partial class SlotControl : UserControl
        {
        #region Enums
        public enum SCStyle
            {
            Normal,
            Core,
            };

        public enum SCType
            {
            Active,
            Passive,
            };

        public enum SCBorder
            {
            None,
            Available,
            Unavailable,
            Locked,
            };

        public enum SCState
            {
            Design,
            Base,
            Selected,
            };

        #endregion

        #region Member variables
        private SCStyle ControlStyle;
        private SCType ControlType;
        private SCBorder ControlBorder;
        private SCState ControlState;
        private string ControlText;
        private string BaseIconFileName;
        private bool DisplayMode;

        //Graphic Locations
        private PointF IconLocation = new PointF(0.10f, 0.10f);
        private PointF SlotLocation = new PointF(0.00f, 0.00f);
        private PointF CoreBackgroundLocation = new PointF(0.08f, 0.08f);
        private PointF BorderLocation = new PointF(0.04f, 0.03f);
        private PointF WhiteBorderLocation = new PointF(0.00f, 0.00f);
        private PointF IconBorderLocation = new PointF(0.08f, 0.08f);

        //Border Graphics
        private IconClass SlotBorderWhiteActive;
        private IconClass SlotBorderWhitePassive;
        private IconClass SlotBorderRedActive;
        private IconClass SlotBorderRedPassive;
        private IconClass SlotBorderLockedActive;
        private IconClass SlotBorderLockedPassive;

        //Slot Background Graphics
        private IconClass SlotBackgroundActive;
        private IconClass SlotBackgroundPassive;
        private IconClass SlotCoreBackgroundActive;
        private IconClass SlotCoreBackgroundPassive;

        //Icons and Icon Borders
        private IconClass IconEmptyActive;
        private IconClass IconEmptyPassive;
        private IconClass BaseIcon;
        private IconClass IconBorderPassive;
        private IconClass IconBorderActive;

        #endregion

        #region Properties
        [Category("_SlotControl")]
        public SCStyle SlotStyle
            {
            get { return ControlStyle; }
            set
                {
                ControlStyle = value;
                }
            }

        [Category("_SlotControl")]
        public SCType SlotType
            {
            get { return ControlType; }
            set
                {
                ControlType = value;
                Invalidate();
                //this.Invalidate();
                }
            }

        [Category("_SlotControl")]
        public SCBorder SlotBorder
            {
            get { return ControlBorder; }
            set
                {
                ControlBorder = value;
                Invalidate();
                }
            }

        [Category("_SlotControl")]
        public SCState SlotState
            {
            get { return ControlState; }
            set
                {
                ControlState = value;
                }
            }

        [Category("_SlotControl")]
        public string SlotText
            {
            get { return ControlText; }
            set
                {
                ControlText = value;
                TextLabel.Text = ControlText;
                }
            }

        #endregion

        #region Constructors
        public SlotControl()
            {
            InitializeComponent();
            SetDefaults();

            //Set up the graphics.
            SlotBorderWhiteActive = new IconClass("Interface\\SlotBorderWhiteActive");
            SlotBorderWhiteActive.SetLocation(this.Width, this.Height, WhiteBorderLocation);
            SlotBorderWhitePassive = new IconClass("Interface\\SlotBorderWhitePassive");
            SlotBorderWhitePassive.SetLocation(this.Width, this.Height, WhiteBorderLocation);

            SlotBorderRedActive = new IconClass("Interface\\SlotBorderRedActive");
            SlotBorderRedActive.SetLocation(this.Width, this.Height, BorderLocation);
            SlotBorderRedPassive = new IconClass("InterFace\\SlotBorderRedPassive");
            SlotBorderRedPassive.SetLocation(this.Width, this.Height, BorderLocation);

            SlotBorderLockedActive = new IconClass("Interface\\SlotBorderLockedActive");
            SlotBorderLockedActive.SetLocation(this.Width, this.Height, BorderLocation);
            SlotBorderLockedPassive = new IconClass("Interface\\SlotBorderLockedPassive");
            SlotBorderLockedPassive.SetLocation(this.Width, this.Height, BorderLocation);

            SlotCoreBackgroundActive = new IconClass("Interface\\SlotCoreBackgroundActive");
            SlotCoreBackgroundActive.SetLocation(this.Width, this.Height, CoreBackgroundLocation);
            SlotCoreBackgroundPassive = new IconClass("Interface\\SlotCoreBackgroundPassive");
            SlotCoreBackgroundPassive.SetLocation(this.Width, this.Height, CoreBackgroundLocation);

            SlotBackgroundActive = new IconClass("Interface\\SlotBackgroundActive");
            SlotBackgroundActive.SetLocation(this.Width, this.Height, SlotLocation);
            SlotBackgroundPassive = new IconClass("Interface\\SlotBackgroundPassive");
            SlotBackgroundPassive.SetLocation(this.Width, this.Height, SlotLocation);

            BaseIcon = new IconClass("Interface\\Test");
            BaseIcon.SetLocation(this.Width, this.Height, IconLocation);

            IconEmptyActive = new IconClass("Interface\\IconEmptyActive");
            IconEmptyActive.SetLocation(this.Width, this.Height, IconLocation);
            IconEmptyPassive = new IconClass("Interface\\IconEmptyPassive");
            IconEmptyPassive.SetLocation(this.Width, this.Height, IconLocation);

            IconBorderActive = new IconClass("Interface\\IconBorderActive");
            IconBorderActive.SetLocation(this.Width, this.Height, IconBorderLocation);
            IconBorderPassive = new IconClass("Interface\\IconBorderPassive");
            IconBorderPassive.SetLocation(this.Width, this.Height, IconBorderLocation);
            }
        
        #endregion

        #region Events
        private void OnPaint(object sender, PaintEventArgs paintEventArgs)
            {
            DrawSlot(paintEventArgs);
            }

        #endregion

        #region Protected Methods
        #endregion

        #region Private Methods
        private void DrawSlot(PaintEventArgs paintEventArgs)
            {
            if (DisplayMode == true)
                {
                if (ControlType == SCType.Active)
                    //Drawing Active Slots
                    {
                    //Normal or Core Background
                    if (ControlStyle == SCStyle.Normal)
                        SlotBackgroundActive.Draw(paintEventArgs);
                    else
                        SlotCoreBackgroundActive.Draw(paintEventArgs);
                    //Empty Icon or Base Icon
                    if (ControlState == SCState.Design)
                        IconEmptyActive.Draw(paintEventArgs);
                    else
                        BaseIcon.Draw(paintEventArgs);
                    //Icon Border
                    IconBorderActive.Draw(paintEventArgs);
                    //Slot Border
                    if (ControlBorder == SCBorder.Available)
                        SlotBorderWhiteActive.Draw(paintEventArgs);
                    else if (ControlBorder == SCBorder.Unavailable)
                        SlotBorderRedActive.Draw(paintEventArgs);
                    else if (ControlBorder == SCBorder.Locked)
                        SlotBorderLockedActive.Draw(paintEventArgs);
                    }
                else
                    //Drawing Passive Slots
                    {
                    //Normal or Core Background
                    if (ControlStyle == SCStyle.Normal)
                        SlotBackgroundPassive.Draw(paintEventArgs);
                    else
                        SlotCoreBackgroundPassive.Draw(paintEventArgs);
                    //Empty Icon or Base Icon
                    if (ControlState == SCState.Design)
                        IconEmptyPassive.Draw(paintEventArgs);
                    else
                        BaseIcon.Draw(paintEventArgs);
                    //Icon Border
                    IconBorderPassive.Draw(paintEventArgs);
                    //Slot Border
                    if (ControlBorder == SCBorder.Available)
                        SlotBorderWhitePassive.Draw(paintEventArgs);
                    else if (ControlBorder == SCBorder.Unavailable)
                        SlotBorderRedPassive.Draw(paintEventArgs);
                    else if (ControlBorder == SCBorder.Locked)
                        SlotBorderLockedPassive.Draw(paintEventArgs);
                    }
                }
            }

        private void SetDefaults()
            {
            ControlStyle = SCStyle.Normal;
            ControlType = SCType.Active;
            ControlBorder = SCBorder.None;
            ControlState = SCState.Design;
            ControlText = "";
            BaseIconFileName = "NoImage";
            DisplayMode = true;
            }

        #endregion

        #region Public Methods
        public void Clear()
            {
            SetDefaults();
            }

        public void SetIcon(string iconName)
            {
            BaseIconFileName = iconName;
            BaseIcon = new IconClass(iconName);
            BaseIcon.SetLocation(this.Width, this.Height, IconLocation);
            Invalidate();
            }

        #endregion



        private void SlotControl_Load(object sender, EventArgs e)
            {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                this.BackColor = Color.Wheat;
            else
                this.BackColor = Color.Transparent;
            }
        }
    }
