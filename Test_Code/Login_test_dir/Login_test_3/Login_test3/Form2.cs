using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Login_test3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        FirebaseConfig fbc = new FirebaseConfig()
        {
            AuthSecret = "D0WK5xAXo5XhSBVN8dlcMxuvp4iRQuu0VypUeVbu",
            BasePath = "https://account-fc107-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var result = client.Get("account/" + txtID.Text);
            Upload upd1 = result.ResultAs<Upload>();

            if(upd1 == null || txtPW.Text!=upd1.pw)
            {
                MessageBox.Show("ID가 존재하지 않거나 비밀번호가 정확하지 않습니다.");
            }
            else
            {
                MessageBox.Show("로그인 성공");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fbc);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            Form1 newform1 = new Form1();
            this.Hide();
            newform1.ShowDialog();
        }
    }
}
