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
    public partial class SetForm : Form
    {
        public SetForm()
        {
            InitializeComponent();
        }

        private void btnStnd_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySet1 mySet1 = new MySet1();
            mySet1.ShowDialog();
        }

        private void btnWrd_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySet1 mySet1 = new MySet1();
            mySet1.ShowDialog();
        }
    }
}
