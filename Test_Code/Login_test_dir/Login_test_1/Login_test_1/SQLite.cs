using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace Login_test_1
{
    public class SQLite
    {
        SQLiteConnection conn = new SQLiteConnection($"server={Config.Server};uid={Config.UserID};" +
            $"pwd={Config.UserPassword};database={Config.Database};pooling=false;allow user variables=true");

        static string DBpath = Application.StartupPath + @"\database.db";
        string dataSource = $@"Data Source={DBpath}";
        SQLiteDataAdapter adpt;
        SQLiteCommand cmd;
        
        public void Connection()
        {
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            conn.Close();
        }
        public DataSet SelectAll(string table)
        {
            try
            {
                DataSet ds = new DataSet();

                string sql = $"SELECT * FROM {table}";
                adpt = new SQLiteDataAdapter(sql, dataSource);
                adpt.Fill(ds, table);

                if (ds.Tables.Count > 0) return ds;
                else return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public DataSet SelectDetail(string table, string condition, string where = "")
        {
            try
            {
                DataSet ds = new DataSet();

                string sql = $"SELECT {condition} FROM {table} {where}";
                adpt = new SQLiteDataAdapter(sql, dataSource);
                adpt.Fill(ds, table);

                if (ds.Tables.Count > 0) return ds;
                else return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public void Insert(string table, string value)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dataSource))
                {
                    conn.Open();
                    string sql = $"INSERT INTO {table} VALUES ({value})";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public void Update(string table, string setvalue, string wherevalue = "")
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dataSource))
                {
                    conn.Open();
                    string sql = $"UPDATE {table} SET {setvalue} WHERE {wherevalue}";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public void DeleteAll(string table)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dataSource))
                {
                    conn.Open();
                    string sql = $"DELETE FROM {table}";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public void DeleteDetail(string table, string wherecol, string wherevalue)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dataSource))
                {
                    conn.Open();
                    string sql = $"DELETE FROM {table} WHERE {wherecol}='{wherevalue}'";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }
    }
}
