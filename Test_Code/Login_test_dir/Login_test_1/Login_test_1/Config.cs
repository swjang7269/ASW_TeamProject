using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_test_1
{
    enum eTName : int { _user }

    class Config
    {
        public static string Database = "login";
        public static string Server = "localhost";
        public static string UserID = "user_id";
        public static string UserPassword = "user_pw";

        public static string[] Tables = { "user" };

        public static DataSet user_ds = null;
    }
}
