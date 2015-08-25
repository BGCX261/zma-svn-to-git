using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Vitt.Andre.MinecraftAdmin.Dialogs
{
    public partial class HelpDialog : Form
    {
        public HelpDialog()
        {
            InitializeComponent();
            this.webBrowser1.Url = new Uri(Path.Combine(Application.StartupPath,Path.Combine("Help","index.html")));
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection tags = webBrowser1.Document.Links;
            foreach (HtmlElement element in tags)
                element.Click += new HtmlElementEventHandler(element_Click);
        }

        void element_Click(object sender, HtmlElementEventArgs e)
        {
           
        }
    }
}
