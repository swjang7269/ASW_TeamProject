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
    public partial class MySet1 : Form
    {
        public MySet1()
        {
            InitializeComponent();
        }

        private void btnInvd_Click(object sender, EventArgs e)
        {
            MySet2 mySet2 = new MySet2();
            mySet2.ShowDialog();
            //개인전 데이터와 이전에 선택했던 모드 데이터 저장
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            MySet2 mySet2 = new MySet2();
            mySet2.ShowDialog();
            //팀전 데이터와 이전에 선택했던 모드 데이터 저장
        }

        private void btnSolo_Click(object sender, EventArgs e)
        {
            MySet2 mySet2 = new MySet2();
            mySet2.ShowDialog();
            //솔로 데이터와 이전에 선택했던 모드 데이터 저장
        }
    }
}
