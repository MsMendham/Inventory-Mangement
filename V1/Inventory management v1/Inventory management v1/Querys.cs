using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Inventory_management_v1
{
    public class Querys
    {
        public static int checkifexist(string username)
        {
            try
            {
                string query = "EXISTS (SELECT username FROM users WHERE users.username = " + username + ")";

                int res = LoginDb.executeQuery(query);
                
                return res;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
