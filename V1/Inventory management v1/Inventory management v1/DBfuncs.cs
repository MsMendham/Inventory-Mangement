using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Inventory_management_v1
{
    class DBfuncs
    {
        public static string queryDB(string query)
        {
            var cs = @"Server=.\SQLEXPRESS;Database=UserDB;Trusted_Connection=True;";
            // defines the connection string when setup this would need to be changed to fit the database
            // that is being used either manully or through a install wizard 
            var con = new SqlConnection(cs);
            con.Open();
            // creates a connection and opens it 

            var cmd = new SqlCommand(query, con);
            object output = cmd.ExecuteScalar();
            string finalout = Convert.ToString(output);
            // creates the sqlcommand and with the query and connection executes the command
            // then converts the object output to a string

            return finalout;
            // returns the value
        }
        
        public static string checkUserExists(string uname)
        {
            string result = queryDB($"EXEC spCheck_User_Exist @Username = {uname}");
            //creates result which is the return value form queryDB from the sql command given
            // this executes the check user exists stored proc
            return result;
        }

        public static string GetUser(string uname, string pword)
        {
            string result = queryDB($"EXEC spUsers_selectID_fromUP @Username = {uname}, @Password = '{pword}';");
            //creates result which is the return value form queryDB from the sql command given
            // this executes the select id using username and password stored proc
            return result;
        }

    }
}
