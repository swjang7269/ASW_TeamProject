using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catch_Music
{
    public partial class MySet3 : Form
    {
        public MySet3()
        {
            InitializeComponent();
        }

        private void btnHigh_Click(object sender, EventArgs e)
        {
            this.Hide();
            MultiChoose multiChoose = new MultiChoose();
            multiChoose.Show();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            this.Hide();
            MultiChoose multiChoose = new MultiChoose();
            multiChoose.Show();
        }

        private void btnLow_Click(object sender, EventArgs e)
        {
            this.Hide();
            MultiChoose multiChoose = new MultiChoose();
            multiChoose.Show();
        }
    }
}
