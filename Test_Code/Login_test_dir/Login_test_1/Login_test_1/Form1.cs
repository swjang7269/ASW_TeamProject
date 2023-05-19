using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_test_1
{
    public partial class Form1 : Form
    {
        public static SQLite _db = new SQLite();

        public bool test = false;
        TextBox[] txtList;
        const string IDPlaceholder = "아이디";
        const string PWPlaceholder = "비밀번호";
        public Form1()
        {
            InitializeComponent();

            //id, pw TextBox Placeholder 설정
            txtList = new TextBox[] { txt_ID, txt_PW };
            foreach (var txt in txtList)
            {
                txt.ForeColor = Color.DarkGray;
                if (txt == txt_ID)
                    txt.Text = IDPlaceholder;
                else if (txt == txt_PW)
                    txt.Text = PWPlaceholder;

                txt.GotFocus += RmPlaceholder;
                txt.LostFocus += SetPlaceholder;
            }
        }

        private void RmPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if(txt.Text == IDPlaceholder | txt.Text == PWPlaceholder)
            {
                txt.ForeColor = Color.Black;
                txt.Text = string.Empty;
                if (txt == txt_PW) 
                    txt_PW.PasswordChar = '●';
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.ForeColor = Color.DarkGray;
                if (txt == txt_ID)
                    txt.Text = IDPlaceholder;
                else if (txt == txt_PW)
                {
                    txt.Text = PWPlaceholder;
                    txt_PW.PasswordChar = default;
                }
            }
        }

        private void Signin_btn_Click(object sender, EventArgs e)
        {
            LoadUserInfo();
            CheckID_PW(txt_ID.Text, txt_PW.Text);
        }

        public static void LoadUserInfo()
        {
            Config.user_ds = _db.SelectAll(Config.Tables[(int)eTName._user]);
        }

        private void CheckID_PW (string id, string pw)
        {
            if (Config.user_ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow row in Config.user_ds.Tables[0].Rows)
                {
                    if (id == row["id"].ToString())
                    {
                        if (pw == row["pw"].ToString()) MessageBox.Show("로그인 성공");
                        else MessageBox.Show("비밀번호가 일치하지 않습니다.");
                    }
                }
            }
            else
            {
                MessageBox.Show("사용자 정보가 없습니다.");
            }
        }
    }
}
