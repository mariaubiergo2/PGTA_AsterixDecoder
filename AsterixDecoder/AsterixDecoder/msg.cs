using System;
using System.Windows.Forms;

namespace AsterixDecoder
{
    public partial class msg : Form
    {
        public msg(string labelTxt)
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
