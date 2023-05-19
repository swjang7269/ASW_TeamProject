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
    public partial class MySet1 : Form
    {
        public MySet1()
        {
            InitializeComponent();
        }

        private void btnStandard_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySet2 mySet2 = new MySet2();
            mySet2.ShowDialog();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySet2 mySet2 = new MySet2();
            mySet2.ShowDialog();
        }
    }
}
