using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.Controls
    {
    public partial class TreeControl : UserControl
        {
        #region Enums
        public enum TCMode
            {
            Design,
            Display,
            };

        public enum TCType
            {
            Destiny,
            Enhancement
            };

        #endregion

        #region Member Variables
        private TCMode TreeMode; //-> was trying to use this for a design only mode
        //private TCType TreeType; -> This will be used if I decide to use this with the Destiny Trees also.
        private string TreeName;
        private int NumberofSlots;
        private bool ShowSelectableBorder;
        private int SlotSelectedIndex;
        
        public bool Tier5Lock;

        //Event declarations.
        public event EventHandler SelectedIndexChanged;
        public event EventHandler ButtonClick;
        public event EventHandler<TreeEventArgs> SlotAdded;
        public event EventHandler<TreeEventArgs> SlotRemoved;
        public event EventHandler<TreeEventArgs> SlotMouseClick;
        public event EventHandler<TreeEventArgs> SlotMouseDoubleClick;

        #endregion

        #region Properties
        [Category("_TreeControl")]
        public TCMode DisplayMode
            {
            get { return TreeMode; }
            set { TreeMode = value; }
            }

        [Category("_TreeControl")]
        public string TreeText
            {
            get { return TreeName; }
            set
                {
                TreeName = value;
                TreeNameLabel.Text = TreeName;
                }
            }

        [Category("_TreeControl")]
        public bool SelectableMode
            {
            get { return ShowSelectableBorder; }
            set { ShowSelectableBorder = value; }
            }

        [Category("_TreeControl")]
        public int SelectedIndex
            {
            get { return SlotSelectedIndex; }
            set { ChangeSelectedIndex(value); }
            }

        [Category("_TreeControl")]
        public string ButtonText
            {
            get {return ResetTreeButton.Text; }
            set { ResetTreeButton.Text = value.ToString(); }
            }

        [Category("_TreeControl")]
        public string APSpentText
            {
            get { return APSpentLabel.Text; }
            set { APSpentLabel.Text = value; }
            }

        #endregion

        #region Form Control Events
        private void btnShowSlot_Click(object sender, EventArgs e)
            {
            int buttonIndex;

            buttonIndex = GetbtnShowSlotIndex(sender);
            ShowSlot(buttonIndex, true);
            SelectedIndex = buttonIndex;
            this.OnSlotAdded(new TreeEventArgs(buttonIndex, MouseButtons.None));
            }

        private void slotControl_MouseClick(object sender, MouseEventArgs e)
            {
            int slotIndex;

            slotIndex = GetSlotControlIndex(sender);
            SelectedIndex = slotIndex;

            this.OnSlotMouseClick(new TreeEventArgs(slotIndex, e.Button));
            }

        private void slotControl_MouseDoubleClick(object sender, MouseEventArgs e)
            {
            int slotIndex;

            slotIndex = GetSlotControlIndex(sender);
            SelectedIndex = slotIndex;

            this.OnSlotMouseDoubleClick(new TreeEventArgs(slotIndex, e.Button));
            }

        private void ResetTreeButton_Click(object sender, EventArgs e)
            {
            this.OnButtonClick(EventArgs.Empty);
            }

        #endregion

        #region Tree Control Events
        protected virtual void OnSelectedIndexChanged(EventArgs e)
            {
            EventHandler handler = this.SelectedIndexChanged;
            if (handler != null)
                {
                handler(this, e);
                }
            }

        protected virtual void OnButtonClick(EventArgs e)
            {
            EventHandler handler = this.ButtonClick;
            if (handler != null)
                {
                handler(this, e);
                }
            }

        protected virtual void OnSlotAdded(TreeEventArgs e)
            {
            EventHandler<TreeEventArgs> handler = this.SlotAdded;
            if (handler != null)
                handler(this, e);
            }

        protected virtual void OnSlotRemoved(TreeEventArgs e)
            {
            EventHandler<TreeEventArgs> handler = this.SlotRemoved;
            if (handler != null)
                handler(this, e);
            }

        protected virtual void OnSlotMouseClick(TreeEventArgs e)
            {
            EventHandler<TreeEventArgs> handler = this.SlotMouseClick;
            if (handler != null)
                handler(this, e);
            }

        protected virtual void OnSlotMouseDoubleClick(TreeEventArgs e)
            {
            EventHandler<TreeEventArgs> handler = this.SlotMouseDoubleClick;
            if (handler != null)
                handler(this, e);
            }

        #endregion

        #region Constructors
        public TreeControl()
            {
            InitializeComponent();

            NumberofSlots = 31;
            if (TreeMode == TCMode.Design)
                ShowbtnSlots(true);
            else
                ShowbtnSlots(false);
            
            }

        #endregion

        #region Private Methods
        private void ChangeSelectedIndex(int newIndex)
            {
            SlotControl oldSelectedSlot;
            SlotControl newSelectedSlot;
            string slotName;

            //Check to see if we need to show a border on selection
            if (ShowSelectableBorder == true)
                {
                //Make sure new slot selected isn't already selected
                if (SlotSelectedIndex != newIndex)
                    {
                    //Unselect the old select if one is selected
                    if (SlotSelectedIndex > -1)
                        {
                        slotName = GetSlotControlName(SlotSelectedIndex);
                        oldSelectedSlot = (SlotControl)this.Controls[slotName];
                        oldSelectedSlot.SlotBorder = SlotControl.SCBorder.None;
                        }
                    //Now lets set the Selected Slot unless the index is -1
                    if (newIndex != -1)
                        {
                        slotName = GetSlotControlName(newIndex);
                        newSelectedSlot = (SlotControl)this.Controls[slotName];
                        newSelectedSlot.SlotBorder = SlotControl.SCBorder.Available;
                        }
                    }
                }
            //Now we can change the actual index and trigger an event, so the user has something to respond to.
            SlotSelectedIndex = newIndex;
            this.OnSelectedIndexChanged(EventArgs.Empty);

            }    

        private string GetSlotControlName(int index)
            {
            string slotName;

            slotName = "slotControl" + index;
            return slotName;
            }

        private int GetSlotControlIndex(object sender)
            {
            SlotControl slot;
            string slotIndexString;
            int slotIndex;

            //extract the index value of the slot control
            slot = new SlotControl();
            slot = (SlotControl)sender;
            slotIndexString = Regex.Match(slot.Name, @"\d+").Value;
            slotIndex = Int32.Parse(slotIndexString);

            return slotIndex;
            }

        private int GetbtnShowSlotIndex(object sender)
            {
            Button button;
            string buttonIndexString;
            int buttonIndex;

            //extract the index value of the slot control
            button = new Button();
            button = (Button)sender;
            buttonIndexString = Regex.Match(button.Name, @"\d+").Value;
            buttonIndex = Int32.Parse(buttonIndexString);

            return buttonIndex;
            }

        private void ShowSlot(int index, bool flag)
            {
            SlotControl slotControl;
            Button buttonControl;
            string slotName;
            string buttonName;

            slotName = "slotControl" + index;
            buttonName = "btnShowSlot" + index;

            buttonControl = (Button)this.Controls[buttonName];
            slotControl = (SlotControl)this.Controls[slotName];

            if (DisplayMode == TCMode.Design)
                buttonControl.Visible = !flag;
            else
                buttonControl.Visible = false;
            slotControl.Visible = flag;
            }

        private void ShowAllSlots(bool flag)
            {
            for (int i = 0; i < NumberofSlots; i++)
                {
                ShowSlot(i, flag);
                }
            }

        private void ShowbtnSlots(bool flag)
            {
            Button buttonControl;
            string buttonName;

            for (int i = 0; i < 31; i++)
                {
                buttonName = "btnShowSlot" + i;
                buttonControl = (Button)this.Controls[buttonName];
                if (DisplayMode == TCMode.Design)
                    buttonControl.Visible = flag;
                else
                    buttonControl.Visible = false;
                }
            }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add a slot to the TreeControl
        /// </summary>
        /// <param name="index">this is an int represent where on the tree you want the slot</param>
        public void AddSlot(int index)
            {
            if (index < 0 || index > 30)
                return;
            ShowSlot(index, true);

            this.OnSlotAdded(new TreeEventArgs(index, MouseButtons.None));
            }

        /// <summary>
        /// Remove a slot from the TreeControl
        /// </summary>
        /// <param name="index">an Interger represent the slot you want removed.</param>
        public void RemoveSlot(int index)
            {
            if (index < 0 || index > 30)
                return;
            ShowSlot(index, false);

            this.OnSlotRemoved(new TreeEventArgs(index, MouseButtons.None));
            }

        public bool IsSlotShowing(int index)
            {
            SlotControl slotControl;
            string slotName;

            slotName = "slotControl" + index;
            slotControl = (SlotControl)this.Controls[slotName];

            return slotControl.Visible;
            }

        public void Clear()
            {
            ShowAllSlots(false);
            }

        public void ChangeSlotType(int index, SlotControl.SCType type)
            {
            SlotControl slot;
            string slotName;

            slotName = "slotControl" + index;
            slot = (SlotControl)this.Controls[slotName];
           
            slot.SlotType = type;
            }
        public void ChangeSlotIcon(int index, string IconName)
        {
            SlotControl slot;
            string slotName;

            slotName = "slotControl" + index;
            slot = (SlotControl)this.Controls[slotName];

            slot.SetIcon("Enhancements\\" + IconName);
            if(IconName.IndexOf("Design")>0)
            {
                slot.SlotState = SlotControl.SCState.Design;
            }
            else
            {
                slot.SlotState = SlotControl.SCState.Base;
            }
            

        }

        #endregion

        public class TreeEventArgs : EventArgs
            {
            private int slotIndex;
            private MouseButtons mouseButton;

            public TreeEventArgs(int slotIndex, MouseButtons button)
                {
                this.slotIndex = slotIndex;
                this.mouseButton = button;
                }

            public int SlotIndex
                {
                get { return slotIndex; }
                }

            public MouseButtons MouseButton
                {
                get { return mouseButton; }
                }
            }

        private void TreeControl_Load(object sender, EventArgs e)
            {
            
            }

        }
    }
