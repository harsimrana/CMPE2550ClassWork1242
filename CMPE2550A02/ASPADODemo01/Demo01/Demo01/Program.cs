

using Microsoft.Data.SqlClient;

namespace Demo01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "ASP ADO Demo 01!");

            //Define a connection string that included information about database

            string connectionString = "Server = data.cnt.sast.ca,24680;" +
                                      "Database = demo_db2550_Northwind;" +
                                      "User Id = demoUser;" +
                                      "Password = temP2020#;" +
                                      "Encrypt = false";


            app.MapGet("/RetrieveData", () =>
            {
                Console.WriteLine("Inside RetrieveData endpoint");

               
                try  // Try to open a connection so using try catch block
                {
                    // Step 1: Establish a connection a to DB
                    // Pass connection string here
                    // Use SQLConnection class to open a connection
                    SqlConnection connection = new SqlConnection(connectionString);

                    //Step 2: Open the connection

                    connection.Open();
                    Console.WriteLine("Connection is open now");



                }
                catch (Exception e)
                {
                    Console.WriteLine("Error While Establishing connection");
                }

            });

            app.Run();
        }
    }
}
