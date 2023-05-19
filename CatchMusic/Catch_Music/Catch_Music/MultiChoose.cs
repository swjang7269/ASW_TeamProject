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
    public partial class MultiChoose : Form
    {
        //string name = ""; // 로그인 했을 때 주어지는 닉네임을 저장할 변수

        public MultiChoose()
        {
            InitializeComponent();
        }

        private void makeBtn_Click(object sender, EventArgs e)
        {
            Server sv = new Server();
            sv.Show(); // 테스트때문에 ShowDialog()가 아닌 Show() 사용
            //this.Close();
        }

        private void multiBtn_Click(object sender, EventArgs e)
        {
            Client ce = new Client();
            ce.Show(); // 테스트때문에 ShowDialog()가 아닌 Show() 사용
            //this.Close();
        }

        private void MultiChoose_Load(object sender, EventArgs e)
        {

        }
    }
}
