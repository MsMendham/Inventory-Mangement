using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Inventory_management_v1
{
    class MainDbFuncs
    {
        // Function to query the Items Database and return the result
        private static SqlDataReader QueryMainDB(string query) 
        {
            var cs = @"Server=.\SQLEXPRESS;Database=ItemsDB;Trusted_Connection=True;";
            // defines the connection string when setup this would need to be changed to fit the database
            // that is being used either manully or through a install wizard 
            var con = new SqlConnection(cs);
            // creats a connection

            try
            {
                con.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine("Problem with database. Contact Database Administrator");
                Console.WriteLine(e.Message);
            }
            // opens a connection unless an error is thrown
            // if an error is thrown gives an error message and errorm code

            var cmd = new SqlCommand(query, con);
            SqlDataReader output;
            // creats the command to be executed
            // creates the output object

            try
            {
                output = cmd.ExecuteReader();
            }
            catch(Exception e)
            {
                output = null;
                Console.WriteLine(e);
            }
            // executes the command and stores the result in output
            // if an error is thrown set output to null and gives the error code

            return output;
            // returns the output
        }

        public static List<object> getItems()
        {
            SqlDataReader reader = QueryMainDB("EXEC sp_get @param1 = 1"); // querys the database for the items table
            
            List<object> Items = new List<object>(); // creates a list that will contain objects

            // creates a loop that incremnts the record of the reader each loop and will stop after there are no records left
            // the loop then creates an object using the data it got from the database and adds it to the items list
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                
                object item = new Item(id, name, type);

                Items.Add(item);
            }
            return Items;// returns the list
        }

        // test above func works future me  then document it:)) 
    }
}
