using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeBrowser
{
    public partial class WeBrowser : Form
    {
        public WeBrowser()
        {
            InitializeComponent();
            webBrowser1.Navigate("https://www.google.co.uk/");
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void NavigateToPage()
        {
            webBrowser1.Navigate(txtUrl.Text);
            txtUrl.Enabled = false;
            btnBack.Enabled = false;
            btnForward.Enabled = false;
           
        }

        private void txtUrl_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                NavigateToPage();

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == " Type Web Address")
            {
                webBrowser1.Refresh();
            }
            else if (!string.IsNullOrEmpty(txtUrl.Text))

                NavigateToPage();

        }

        private void txtUrl_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUrl.Text == " Type Web Address")
            {
                txtUrl.Text = "";
            }
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
                {
                    progressBar1.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
                }
            }
            catch (Exception)
            {

                return;
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.co.uk/");
            txtUrl.Text = "";
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnGo.Enabled = true;
            txtUrl.Enabled = true;
            btnBack.Enabled = true;
            btnForward.Enabled = true;
            btnHome.Enabled = true;

        }

    }
}
