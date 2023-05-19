using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testcase1
{
    public partial class SetForm : Form
    {
        public SetForm()
        {
            InitializeComponent();
        }

        private void btnStnd_Click(object sender, EventArgs e)
        {
            MySet1 mySet1 = new MySet1();
            mySet1.ShowDialog();
            //기본 모드 데이터 저장 (코드 추가)
        }

        private void btnWrd_Click(object sender, EventArgs e)
        {
            MySet1 mySet1 = new MySet1();
            mySet1.ShowDialog();
            //초성 모드 데이터 저장 (코드 추가)
        }
    }
}
