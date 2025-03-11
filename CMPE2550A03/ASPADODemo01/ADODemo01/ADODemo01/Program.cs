using Microsoft.Data.SqlClient;

namespace ADODemo01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Default end point
            app.MapGet("/", () => "ADO Demo 01");

            // Define a connection string that includes information about the database

            string connectionString =   "Server = data.cnt.sast.ca,24680;" +
                                        "Database = demo_db2550_Northwind;" +
                                        "User Id = demoUser;" +
                                        "Password = temP2020#;" +
                                        "Encrypt = false;"; 

            app.MapGet("/RetrieveEmployee", () =>
            {
                Console.WriteLine("Inside Ret Emp Endpoint");

                try
                {

                    // Step 1 : Establish a connetion to DB
                    // Use SQLConnection class to opne a connection
                    // Pass connection string

                    SqlConnection connection = new SqlConnection(connectionString);

                    // Step 2: Open the connection
                    connection.Open();

                    Console.WriteLine("Connection is open now");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while working database " + e.Message);
                }

            });
            
            app.Run();
        }
    }
}
