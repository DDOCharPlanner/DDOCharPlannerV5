using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using mshtml;

namespace DDOCharacterPlanner.Screens.Controls
    {
    public partial class HTMLEditor : UserControl
        {
        #region Member Variables
        //private IHTMLDocument2 doc;
        private string HCText;
        private Color HCBackgroundColor;
        private Color HCForeColor;
        
        private const string DefaultHTML = "<html><style>body {background-color: #373737; color:white;}</style><body contentEditable='true'>Enter Description Here</body><html>";
        private const string DefaultHtmlHeader = "<html><style>body {background-color: #373737; color:grey;}</style><body contentEditable='true'>";
        private const string DefaultHtmlFooter = "</body></html>";
        #endregion 

        #region Constructor
        public HTMLEditor()
            {
            InitializeComponent();
            HCBackgroundColor = Color.FromArgb(37, 37, 37);
            HCForeColor = Color.White;
            }
        #endregion

        #region Properties
        [Category("_HTMLEditor")]
        public Color BackgroundColor
            {
            get { return HCBackgroundColor; }
            set { HCBackgroundColor = value; }
            }
        [Category("_HTMLEditor")]
        public Color MainFontColor
            {
            get { return HCForeColor; }
            set { HCForeColor = value; }
            }

        [Category("_HTMLEditor")]
        public override string Text
            {
            get {return HCText;}
            set { HCText = value;
            UpdateBroswer(value);
            }
            }

        #endregion

        #region Form Events
        private void HTMLEditor_Load(object sender, EventArgs e)
            {
            //this will get our HTML editor ready
            //webBrowser1.DocumentText = DefaultHTML;
            //make the web browser an editable HTML Field
            //doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
            //doc.designMode = "On";
            }

        private void HTMLEditor_Leave(object sender, EventArgs e)
            {
            //HCText = webBrowser1.Document.Body.InnerText;

            //Testing
            if (webBrowser1.Document != null)
            HCText = webBrowser1.Document.Body.InnerHtml;
            //HCText = webBrowser1.Document.Body.OuterHtml;
            }
        
        #endregion

        #region ToolStrip Events
        private void tsbBold_Click(object sender, EventArgs e)
            {
            webBrowser1.Document.ExecCommand("Bold", false, null);
            }

        private void tsbItalic_Click(object sender, EventArgs e)
            {
            webBrowser1.Document.ExecCommand("Italic", false, null);
            }

        private void tsbUnderline_Click(object sender, EventArgs e)
            {
            webBrowser1.Document.ExecCommand("Underline", false, null);
            }

        private void tsbAlignLeft_Click(object sender, EventArgs e)
            {
            webBrowser1.Document.ExecCommand("JustifyLeft", false, null);
            }

        private void tsbAlignCenter_Click(object sender, EventArgs e)
            {
            webBrowser1.Document.ExecCommand("JustifyCenter", false, null);
            }

        private void tsbAlignRight_Click(object sender, EventArgs e)
            {
            webBrowser1.Document.ExecCommand("JustifyRight", false, null);
            }

        private void tsbFontColor_Click(object sender, EventArgs e)
            {
            ColorDialog colorbox = new ColorDialog();
            if (colorbox.ShowDialog() == DialogResult.OK)
                webBrowser1.Document.ExecCommand("ForeColor", false, colorbox.Color);
            }

        #endregion

        #region Private Members
        private void UpdateBroswer(string text)
            {
            text = WrapTextWithHTMLTags(text);
            webBrowser1.Navigate("about:blank");
            webBrowser1.Document.OpenNew(false);
            webBrowser1.Document.Write(text);
            webBrowser1.Refresh();
            }

        private string WrapTextWithHTMLTags(string text)
            {
            string wrappedText;
            wrappedText = "";

            wrappedText = DefaultHtmlHeader + text + DefaultHtmlFooter;

            return wrappedText;
            }
        #endregion
        }
    }
