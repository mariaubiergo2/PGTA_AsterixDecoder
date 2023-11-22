using System;
using System.Windows.Forms;

namespace AsterixDecoder
{
    public partial class msg_UNUSED : Form
    {
        public msg_UNUSED(string labelTxt)
        {
            InitializeComponent();

            txtLbl.Text = labelTxt;

        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
