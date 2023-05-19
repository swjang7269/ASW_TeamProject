using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Login_test_2
{
    public partial class Form1 : Form
    {
        public bool test = false;
        TextBox[] txtList;
        const string IDPlaceholder = "아이디";
        const string PWPlaceholder = "비밀번호";
        SQLiteConnection connection;
        SQLiteCommand command;

        public Form1()
        {
            InitializeComponent();

            txtList = new TextBox[] { txtID, txtPW };
            foreach (var txt in txtList)
            {
                txt.ForeColor = Color.DarkGray;
                if (txt == txtID)
                    txt.Text = IDPlaceholder;
                else if (txt == txtPW)
                    txt.Text = PWPlaceholder;

                txt.GotFocus += RemovePlaceholder;
                txt.LostFocus += SetPlaceholder;
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text == IDPlaceholder | txt.Text == PWPlaceholder)
            {
                txt.ForeColor = Color.Black;
                txt.Text = string.Empty;
                if (txt==txtPW)
                    txtPW.PasswordChar = '●';
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.ForeColor = Color.DarkGray;
                if (txt == txtID)
                    txt.Text = IDPlaceholder;
                else if (txt == txtPW)
                {
                    txt.Text = PWPlaceholder;
                    txtPW.PasswordChar = default;
                }
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            Form2 newform2 = new Form2();
            this.Hide();
            newform2.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int loginStatus = 0; // 1이면 로그인 성공
            string loginID = txtID.Text;
            string loginPW = txtPW.Text;

            try
            {
                connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/member.db");
                connection.Open();

                command = new SQLiteCommand(connection);
                command.CommandText = "CREATE TABLE IF NOT EXISTS member (" +
                    "id TEXT UNIQUE NOT NULL, " +
                    "pw TEXT NOT NULL, " +
                    "name Text NOT NULL, " +
                    "birthday TEXT NOT NULL)";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT * FROM member WHERE id = " + loginID + "";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (loginID == reader["id"] .ToString()&& loginPW == reader["pw"].ToString())
                    {
                        loginStatus = 1;
                    }
                }
                reader.Close();           
                if (loginStatus == 1)
                {
                    MessageBox.Show("로그인 성공");
                }
                else
                {
                    MessageBox.Show("회원 정보를 확인해 주세요.");
                 }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }
    }
}