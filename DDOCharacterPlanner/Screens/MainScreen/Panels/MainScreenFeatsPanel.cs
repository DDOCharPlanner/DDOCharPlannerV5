using DDOCharacterPlanner.CharacterData;
using DDOCharacterPlanner.Data;
using DDOCharacterPlanner.Utility;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.MainScreen
    {
    public partial class MainScreenFeatsPanel : UserControl
        {
        #region enums
        public enum Featbuttons
            {
            All,
            Granted,
            Selected,
            }
        #endregion

        #region Member Variables
        List<Tuple<string, Guid, string>> TreeCategoryList; //string = nodeName, Guid = categoryId, string = parentNode
        List<Tuple<string, Guid, int>> TreeFeatList;        //string = nodeName, Guid = featId, int = count of that feat
        ImageList IconList;
        Featbuttons ButtonSelected;
        SkinStyleClass ButtonNotSelectedStyle;
        SkinStyleClass ButtonSelectedStyle;

        #endregion

        #region Constructors
        public MainScreenFeatsPanel()
            {
            InitializeComponent();
            TreeCategoryList = new List<Tuple<string, Guid, string>>();
            TreeFeatList = new List<Tuple<string, Guid, int>>();
            IconList = new ImageList();
            IconList.ColorDepth = ColorDepth.Depth32Bit;
            IconList.ImageSize = new Size(24, 24);
            //IconList.TransparentColor = Color.Transparent;
            //FilltreeViewFeats(CharacterData.CharacterFeatCollectionClass.FeatGroup.All, 30);
            ButtonSelected = Featbuttons.All;
            }
        #endregion

        #region Control Events
        private void buttonAllFeats_Click(object sender, EventArgs e)
            {
            FilltreeViewFeats(CharacterData.CharacterFeatCollectionClass.FeatGroup.All);
            ButtonSelected = Featbuttons.All;
            ChangeSelectedButtons(Featbuttons.All);
            }

        private void buttonEditFeats_Click(object sender, EventArgs e)
            {
            FeatsEditScreen featsEditScreen;

            featsEditScreen = new FeatsEditScreen();
            featsEditScreen.Show();
            }

        private void buttonGrantedFeats_Click(object sender, EventArgs e)
            {
            FilltreeViewFeats(CharacterData.CharacterFeatCollectionClass.FeatGroup.Granted);
            ButtonSelected = Featbuttons.Granted;
            ChangeSelectedButtons(Featbuttons.Granted);
            }

        private void buttonSelectedFeats_Click(object sender, EventArgs e)
            {
            FilltreeViewFeats(CharacterData.CharacterFeatCollectionClass.FeatGroup.Selected);
            ButtonSelected = Featbuttons.Selected;
            ChangeSelectedButtons(Featbuttons.Selected);
            }

        #endregion

        #region Private Methods

        private void AddImagetoIconList(Guid featId, bool feat=true)
            {
            string iconName;
            Image img;

            if (IconList.Images.Count == 0)
                {
                img = Image.FromFile(Application.StartupPath + "\\Graphics\\BlankImage.png");
                IconList.Images.Add(img);
                }
            //Lets grab our Icon Name
            if (feat == true)
                iconName = DataManagerClass.DataManager.FeatDataCollection.Feats[featId].IconName;
            else
                iconName = DataManagerClass.DataManager.FeatCategoryDataCollection.FeatCategories[featId].IconName;
            //Let grab the actual image
            try
                {
                img = Image.FromFile(Application.StartupPath + "\\Graphics\\Feats\\" + iconName + ".png");
                }
            catch
                {
                img = Image.FromFile(Application.StartupPath + "\\Graphics\\NoImage.png");
                }
            IconList.Images.Add(img);
            }

        private void AddSubFeats(Guid featId, string featNode, string parentNode, string categoryNode)
            {
            List<Guid> subfeats;

            subfeats = DataManagerClass.DataManager.FeatDataCollection.GetSubfeats(featId);

            for (int i = 0; i < subfeats.Count; i++)
                {
                //add feat to treefeatlist
                TreeFeatList.Add(new Tuple<string, Guid, int>("Feat" + TreeFeatList.Count, subfeats[i], 0));
                //add image to the Iconlist
                AddImagetoIconList(subfeats[i]);
                //add feat to the tree control
                if (parentNode == "" && categoryNode == "")
                    treeViewFeats.Nodes[featNode].Nodes.Add("Feat" + (TreeFeatList.Count - 1), DataManagerClass.DataManager.FeatDataCollection.Feats[subfeats[i]].Name, IconList.Images.Count - 1, IconList.Images.Count - 1);
                else if (parentNode == "Root" && categoryNode != "")
                    treeViewFeats.Nodes[categoryNode].Nodes[featNode].Nodes.Add(
                        "Feat" + (TreeFeatList.Count - 1), DataManagerClass.DataManager.FeatDataCollection.Feats[subfeats[i]].Name, IconList.Images.Count - 1, IconList.Images.Count - 1);
                else
                    treeViewFeats.Nodes[parentNode].Nodes[categoryNode].Nodes[featNode].Nodes.Add(
                        "Feat" + (TreeFeatList.Count - 1), DataManagerClass.DataManager.FeatDataCollection.Feats[subfeats[i]].Name, IconList.Images.Count - 1, IconList.Images.Count -1);
                }
            }

        private void ChangeSelectedButtons(Featbuttons selectedButton)
            {
            switch (selectedButton)
                {
                case Featbuttons.All:
                        {
                        buttonAllFeats.BackColor = ButtonSelectedStyle.Color2;
                        buttonAllFeats.ForeColor = ButtonSelectedStyle.Color1;
                        buttonAllFeats.Font = ButtonSelectedStyle.Font;

                        buttonGrantedFeats.BackColor = ButtonNotSelectedStyle.Color2;
                        buttonGrantedFeats.ForeColor = ButtonNotSelectedStyle.Color1;
                        buttonGrantedFeats.Font = ButtonNotSelectedStyle.Font;
                        buttonSelectedFeats.BackColor = ButtonNotSelectedStyle.Color2;
                        buttonSelectedFeats.ForeColor = ButtonNotSelectedStyle.Color1;
                        buttonSelectedFeats.Font = ButtonNotSelectedStyle.Font;
                        break;
                        }
                case Featbuttons.Granted:
                        {
                        buttonAllFeats.BackColor = ButtonNotSelectedStyle.Color2;
                        buttonAllFeats.ForeColor = ButtonNotSelectedStyle.Color1;
                        buttonAllFeats.Font = ButtonNotSelectedStyle.Font;
                        buttonGrantedFeats.BackColor = ButtonSelectedStyle.Color2;
                        buttonGrantedFeats.ForeColor = ButtonSelectedStyle.Color1;
                        buttonGrantedFeats.Font = ButtonSelectedStyle.Font;
                        buttonSelectedFeats.BackColor = ButtonNotSelectedStyle.Color2;
                        buttonSelectedFeats.ForeColor = ButtonNotSelectedStyle.Color1;
                        buttonSelectedFeats.Font = ButtonNotSelectedStyle.Font;
                        break;
                        }
                case Featbuttons.Selected:
                        {
                        buttonAllFeats.BackColor = ButtonNotSelectedStyle.Color2;
                        buttonAllFeats.ForeColor = ButtonNotSelectedStyle.Color1;
                        buttonAllFeats.Font = ButtonNotSelectedStyle.Font;

                        buttonGrantedFeats.BackColor = ButtonNotSelectedStyle.Color2;
                        buttonGrantedFeats.ForeColor = ButtonNotSelectedStyle.Color1;
                        buttonGrantedFeats.Font = ButtonNotSelectedStyle.Font;
                        buttonSelectedFeats.BackColor = ButtonSelectedStyle.Color2;
                        buttonSelectedFeats.ForeColor = ButtonSelectedStyle.Color1;
                        buttonSelectedFeats.Font = ButtonSelectedStyle.Font;
                        break;
                        }
                }
            }

        private bool DoesCategoryExist(Guid categoryId, out int index)
            {
            //int index = -1;
            index = -1;
            for (int i = 0; i < TreeCategoryList.Count; i++)
                {
                if (TreeCategoryList[i].Item2 == categoryId)
                    {
                    index = i;
                    break;
                    }
                }
            if (index > -1)
                return true;
            return false;
            }

        private void FilltreeViewFeats(CharacterData.CharacterFeatCollectionClass.FeatGroup featGroup, int level = 30)
            {
            List<Tuple<Guid, int>> featList;
            string nodeName;
            Guid categoryId;
            string parentCategory;
            Guid parentCategoryId;
            int index;
            int index2;

            //Lets reset our Lists and TreeView.
            TreeCategoryList.Clear();
            TreeFeatList.Clear();
            treeViewFeats.Nodes.Clear();
            IconList.Images.Clear();
            treeViewFeats.ImageList = IconList;

            featList = CharacterManagerClass.CharacterManager.CharacterFeat.GetKnownFeatsList(featGroup, level);
            //featList.Sort();
            for (int i = 0; i < featList.Count; i++)
                {
                categoryId = DataManagerClass.DataManager.FeatDataCollection.Feats[featList[i].Item1].FeatCategoryId;
                nodeName = "";
                parentCategory = "Root";
                if (categoryId != Guid.Empty)
                    {
                    //this feat belongs in a category, so we need to add it to the correct category node.
                    if (DoesCategoryExist(categoryId, out index))
                        {
                        nodeName = TreeCategoryList[index].Item1;
                        parentCategory = TreeCategoryList[index].Item3;
                        }
                    else //Category doesn't exist so we need to create one.
                        {
                        nodeName = "Category" + TreeCategoryList.Count.ToString();
                        if (DataManagerClass.DataManager.FeatCategoryDataCollection.FeatCategories[categoryId].ParentCategoryId != Guid.Empty)
                            { // need to see if this category belongs to a parent category, if so we then need to add it also
                            if (DoesCategoryExist(categoryId, out index2))
                                {
                                parentCategory = TreeCategoryList[index2].Item3;
                                }
                            else
                                {
                                parentCategory = "Category" + TreeCategoryList.Count;
                                parentCategoryId = DataManagerClass.DataManager.FeatCategoryDataCollection.FeatCategories[categoryId].ParentCategoryId;
                                TreeCategoryList.Add(new Tuple<string, Guid, string>(parentCategory, parentCategoryId, "Root"));
                                AddImagetoIconList(parentCategoryId, false);
                                treeViewFeats.Nodes.Add(parentCategory, DataManagerClass.DataManager.FeatCategoryDataCollection.FeatCategories[parentCategoryId].Name, IconList.Images.Count - 1, IconList.Images.Count - 1);
                                }
                            }
                        else
                            parentCategory = "Root";

                        //Lets add our category to the TreeCategory List
                        TreeCategoryList.Add(new Tuple<string, Guid, string>(nodeName, categoryId, parentCategory));
                        AddImagetoIconList(categoryId, false);
                        //Lets add the category to the treeview now
                        if (parentCategory == "Root")
                            treeViewFeats.Nodes.Add(nodeName, DataManagerClass.DataManager.FeatCategoryDataCollection.FeatCategories[categoryId].Name, IconList.Images.Count - 1, IconList.Images.Count - 1);
                        else
                            treeViewFeats.Nodes[parentCategory].Nodes.Add(nodeName, DataManagerClass.DataManager.FeatCategoryDataCollection.FeatCategories[categoryId].Name, IconList.Images.Count - 1, IconList.Images.Count - 1);
                        }
                    //Now that our categories are added, we can now add the feat into the tree view.
                    TreeFeatList.Add(new Tuple<string, Guid, int>("Feat" + TreeFeatList.Count, featList[i].Item1, featList[i].Item2));
                    AddImagetoIconList(featList[i].Item1);
                    if (parentCategory == "Root")
                        {
                        treeViewFeats.Nodes[nodeName].Nodes.Add("Feat" + (TreeFeatList.Count - 1), DataManagerClass.DataManager.FeatDataCollection.Feats[featList[i].Item1].Name, IconList.Images.Count - 1, IconList.Images.Count - 1);
                        //lets check to see if this feat has any subfeats
                        if (DataManagerClass.DataManager.FeatDataCollection.Feats[featList[i].Item1].IsParentFeat == true)
                            {
                            AddSubFeats(featList[i].Item1, "Feat" + (TreeFeatList.Count - 1), parentCategory, nodeName);
                            }
                        }
                    else
                        {
                        treeViewFeats.Nodes[parentCategory].Nodes[nodeName].Nodes.Add("Feat" + (TreeFeatList.Count - 1), DataManagerClass.DataManager.FeatDataCollection.Feats[featList[i].Item1].Name, IconList.Images.Count - 1, IconList.Images.Count - 1);
                        //lets check to see if this feat has any subfeats
                        if (DataManagerClass.DataManager.FeatDataCollection.Feats[featList[i].Item1].IsParentFeat == true)
                            {
                            AddSubFeats(featList[i].Item1, "Feat" + (TreeFeatList.Count - 1), parentCategory, nodeName);
                            }
                        }
                    }
                else
                    {
                    TreeFeatList.Add(new Tuple<string, Guid, int>("Feat" + (TreeFeatList.Count), featList[i].Item1, featList[i].Item2));
                    AddImagetoIconList(featList[i].Item1);
                    treeViewFeats.Nodes.Add("Feat" + (TreeFeatList.Count - 1), DataManagerClass.DataManager.FeatDataCollection.Feats[featList[i].Item1].Name, IconList.Images.Count - 1, IconList.Images.Count - 1);
                    //lets check to see if this feat has any subfeats
                    if (DataManagerClass.DataManager.FeatDataCollection.Feats[featList[i].Item1].IsParentFeat == true)
                        {
                        AddSubFeats(featList[i].Item1, "Feat" + (TreeFeatList.Count - 1), "", "");
                        }
                    
                    }
                }
            //Now lets sort the tree nodes alphabetically
            treeViewFeats.Sort();
            }

        #endregion

        #region Public Methods
        /// <summary>
		/// Applies the Skin Groups to individual controls
		/// </summary>
        public void ApplySkin()
            {
            SkinStyleClass style;

            //Background
            style = UIManagerClass.UIManager.Skin.GetSkinStyle("MainScreenFeatsPanelBackground");
            this.BackColor = style.Color1;

            //Header
            style = UIManagerClass.UIManager.Skin.GetSkinStyle("MainScreenFeatsPanelHeader");
            labelFeatsPanelHeader.BackColor = style.Color2;
            labelFeatsPanelHeader.ForeColor = style.Color1;
            labelFeatsPanelHeader.Font = style.Font;

            //Header Button
            style = UIManagerClass.UIManager.Skin.GetSkinStyle("MainScreenFeatsPanelHeaderButton");
            buttonEditFeats.BackColor = style.Color2;
            buttonEditFeats.ForeColor = style.Color1;
            buttonEditFeats.Font = style.Font;

            //Feats Tree View control
            style = UIManagerClass.UIManager.Skin.GetSkinStyle("MainScreenFeatsPanelFeatsList");
            treeViewFeats.BackColor = style.Color2;
            treeViewFeats.ForeColor = style.Color1;
            treeViewFeats.Font = style.Font;

            //Button choices
            ButtonNotSelectedStyle = UIManagerClass.UIManager.Skin.GetSkinStyle("MainScreenFeatsPanelButton");
            ButtonSelectedStyle = UIManagerClass.UIManager.Skin.GetSkinStyle("MainScreenFeatsPanelButtonSelected");
            ChangeSelectedButtons(ButtonSelected);
            }

        public void FeatChange(int characterLevel)
            {
            switch (ButtonSelected)
                {
                case Featbuttons.All:
                        {
                        FilltreeViewFeats(CharacterData.CharacterFeatCollectionClass.FeatGroup.All, characterLevel);
                        break;
                        }
                case Featbuttons.Granted:
                        {
                        FilltreeViewFeats(CharacterData.CharacterFeatCollectionClass.FeatGroup.Granted, characterLevel);
                        break;
                        }
                case Featbuttons.Selected:
                        {
                        FilltreeViewFeats(CharacterData.CharacterFeatCollectionClass.FeatGroup.Selected, characterLevel);
                        break;
                        }
                }
            }

        #endregion

        #region Public Static Methods
        /// <summary>
        /// Creates the Skin Group associations with factory settings
        /// </summary>
        public static void RegisterSkinGroups()
            {
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("MainScreenFeatsPanelBackground", SkinSettings.FactoryName.PanelBackgroundColor);
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("MainScreenFeatsPanelHeader", SkinSettings.FactoryName.PanelHeader);
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("MainScreenFeatsPanelHeaderButton", SkinSettings.FactoryName.PanelHeaderButton);
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("MainScreenFeatsPanelFeatsList", SkinSettings.FactoryName.ListControl);
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("MainScreenFeatsPanelButton", SkinSettings.FactoryName.StandardButton);
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("MainScreenFeatsPanelButtonSelected", SkinSettings.FactoryName.StandardButtonSelected);
            }

        #endregion
        }
    }
