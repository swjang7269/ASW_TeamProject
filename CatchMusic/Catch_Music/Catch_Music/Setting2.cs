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
    public partial class MySet2 : Form
    {
        public MySet2()
        {
            InitializeComponent();
        }

        private void btnIndividual_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySet3 mySet3 = new MySet3();
            mySet3.ShowDialog();
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySet3 mySet3 = new MySet3();
            mySet3.ShowDialog();
        }

        private void btnSolo_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySet3 mySet3 = new MySet3();
            mySet3.ShowDialog();
        }
    }
}
