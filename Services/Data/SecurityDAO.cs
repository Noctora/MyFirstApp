using MyFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyFirstApp.Services.Data
{
    public class SecurityDAO
    {
        //connect to the database
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal bool FindByUser(UserModel user)
        {

            //simple return direct
            //return (user.Username == "Admin" && user.Password == "123");

            // start by assuming that nothing is found in this query
            bool success = false;

            // write the sql expression
            string queryString = "SELECT * FROM dbo.Users WHERE username = @Username AND password = @Password";

            // create and open the connection to the database inside a using block.

            // This ensures that all resources are closed properly when the query is done.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // create the command and parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);

                // associate @username with user.username
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                // open the database and run the command.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }
    }
}