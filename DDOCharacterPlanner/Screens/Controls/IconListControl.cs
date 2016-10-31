using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.Controls
    {
    public partial class IconListControl : UserControl
        {
        #region Enums
        public enum Orientation
            {
            Horizontal,
            Vertical,
            }

        #endregion

        #region Member Variables
        private List<IconControl> IconControls;
        private int _SelectedIndex;
        private Orientation _Orientation;

        //Event Declarations.
        public event EventHandler SelectedIndexChanged;

        #endregion

        #region Properties
        [Category("_IconListControl")]
        public int SelectedIndex
            {
            get { return _SelectedIndex; }
            set { //_SelectedIndex = value;
            if (IconControls.Count > 0)
                {
                //IconControls[_SelectedIndex].Selected = true;
                UpdateSelectedIconBorder(value);
                }
            }
            }

        [Category("_IconListControl")]
        public Orientation ControlOrientation
            {
            get { return _Orientation; }
            set { _Orientation = value;
                ChangeOrientation(value); }
            }

        #endregion

        #region Constructors
        public IconListControl()
            {
            InitializeComponent();
            IconControls = new List<IconControl>();
            }
        #endregion

        #region Events
        private void IconControl_Clicked(object sender, EventArgs e)
            {
            IconControlChange(sender);
            }

        private void IconControl_MouseClick(object sender, MouseEventArgs e)
            {
            if (e.Button == MouseButtons.Right)
                {
                //use this to show a menu or to remove the control
                }
            this.OnMouseClick(e);
            }
        #endregion

        #region Protected Members
        protected virtual void OnSelectedIndexChanged(EventArgs e)
            {
            EventHandler handler = this.SelectedIndexChanged;
            if (handler != null)
                handler(this, e);
            }

        #endregion

        #region Private Members
        private IconControl CreateIconControl(int index, IconControl.ICType type)
            {
            IconControl ic;

            ic = new IconControl();

            ic.IconType = type;
            if (_Orientation == Orientation.Horizontal)
                ic.Location = new Point(index * 60, 0);
            else
                ic.Location = new Point(0, index * 60);
            ic.Name = "IconControl[" + index + "]";
            ic.Availability = true;
            ic.Click += new System.EventHandler(this.IconControl_Clicked);
            return ic;
            
            }

        private void ChangeOrientation(Orientation selectedOrientation)
            {
            if (selectedOrientation == Orientation.Horizontal)
                this.Height = 80;
            else
                this.Width = 80;
            }

        private void IconControlChange(object sender)
            {
            IconControl changedIcon;
            string iconIndexString;
            int iconIndex;
            int oldSelectedIndex;

            //extract the index value of the control sending this message
            changedIcon = new IconControl();
            changedIcon = (IconControl)sender;
            iconIndexString = Regex.Match(changedIcon.Name, @"\d+").Value;
            iconIndex = Int32.Parse(iconIndexString);

            //see if the controls is already selected, if so exit function as we don't need to make any changes.
            if (IconControls[iconIndex].Selected == true)
                return;

            //lets set our new index, but copy the oldindex first for later use.
            oldSelectedIndex = _SelectedIndex;
            _SelectedIndex = iconIndex;

            IconControls[oldSelectedIndex].Selected = false;
            IconControls[_SelectedIndex].Selected = true;

            //Ok now that our internal changes are done, we need to fire of an event that the user can for detecting that the indexChanged.
            this.OnSelectedIndexChanged(EventArgs.Empty);
            }

        private void UpdateSelectedIconBorder(int newSelection)
            {      
            //Lets unselect the previous choice
            if (_SelectedIndex > -1)
                IconControls[_SelectedIndex].Selected = false;

            //Now lets set the new index and show its selection
            IconControls[newSelection].Selected = true;
            _SelectedIndex = newSelection;        
            }

        #endregion

        #region Public Members
        /// <summary>
        /// Use this method to add an IconControl to the list
        /// </summary>
        public void Add()
            {
            int index;

            index = IconControls.Count;

            //Lets create the control and add the control to List and Panel
            IconControls.Add(CreateIconControl(index, IconControl.ICType.Passive));
            panelIconControlList.Controls.Add(IconControls[index]);
            }

        public void Clear()
            {
            //TODO: Need to fill this method out.
            IconControls.Clear();
            panelIconControlList.Controls.Clear();
            _SelectedIndex = -1;
            }

        public int Count()
            {
            return IconControls.Count;
            }

        /// <summary>
        /// use this method to set the Unavailablity red internal border of the IconControl
        /// </summary>
        /// <param name="index"></param> index is the index of the IconControl
        /// <param name="flag"></param> flag: True to show red border, false to not show
        public void SetUnavilabiltyofIcon(int index, bool flag)
            {
            IconControls[index].Availability = !flag;
            }

        /// <summary>
        /// Use this method to add an icon image to the icon control
        /// </summary>
        /// <param name="index"></param> the index of the IconControl
        /// <param name="iconName"></param> a string representative of the IconName and subfolder it reside in "Enhancements\\IconName"
        public void SetIconControlImage(int index, string iconName)
            {
            IconControls[index].SetIcon(iconName);
            //this.Invalidate();
            }


        #endregion

        }
    }
