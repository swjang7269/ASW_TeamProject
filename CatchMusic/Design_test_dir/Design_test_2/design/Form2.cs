using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace design
{
    public partial class MySet1 : Form
    {
        public MySet1()
        {
            InitializeComponent();
        }

        private void btnInvd_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySet2 mySet2 = new MySet2();
            mySet2.ShowDialog();
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySet2 mySet2 = new MySet2();
            mySet2.ShowDialog();
        }

        private void btnSolo_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySet2 mySet2 = new MySet2();
            mySet2.ShowDialog();
        }
    }
}
