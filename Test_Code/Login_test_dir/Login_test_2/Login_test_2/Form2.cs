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
using System.CodeDom;

namespace Login_test_2
{
    public partial class Form2 : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        public Form2()
        {
            InitializeComponent();

            try
            {
                connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/member.db");
                connection.Open();

                command = new SQLiteCommand(connection);
                command.CommandText = "CREATE TABLE IF NOT EXISTS member (" +
                    "id TEXT UNIQUE NOT NULL, " +
                    "pw TEXT NOT NULL, " +
                    "name TEXT NOT NULL, " +
                    "birthday TEXT NOT NULL)";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT * FROM member";
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Close();

            }catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //회원가입
        private void Join_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/member.db");
                connection.Open();

                command = new SQLiteCommand(connection);
                command.CommandText = $"INSERT INTO member (id, pw, name, birthday) VALUES (" +
                    $" '{txtID.Text.Trim()}', '{txtPW.Text.Trim()}', '{txtName.Text.Trim()}','{txtBirth.Text.Trim()}')";
                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("회원가입이 완료되었습니다.");
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
         
        }
    }
}
