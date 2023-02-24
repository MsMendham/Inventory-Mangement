using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Inventory_management_v1
{
    public class Loginfuncs
    {
        public static string Hash(string inp)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(inp));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
         public static int Verify(string username, string password)
        {
            string hashed = Hash(password);
            string databasecheck = DBfuncs.checkUserExists(username);
            string databasematch = DBfuncs.GetUser(username,hashed);
            Console.WriteLine(hashed);
            // hashes the password the queries the database

            if (databasecheck == "")
            {
                return 0; // if the user doesnt exists return 0
            }
            if(databasematch == "")
            {
                return -1; // if the password doesnt match the user return -1
            }

            return Convert.ToInt32(databasematch); // otherwise return the userID

        }
        
    } 
}
