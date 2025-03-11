

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

                    connection.Open();  // to open connection
                    Console.WriteLine("Connection is open now");

                    //Step 3: Prepare your query
                    string query = "select * from Employees";

                    //Step 4: Execute SQl query directly from C# code
                    // SqlCommand class object is required
                    // Need to pass query and connection object
                                                // Query , connection object
                    SqlCommand command = new SqlCommand(query, connection);

                    // Step 5: Run your query
                    // ExecuteReader() - to run your retieval queries

                    SqlDataReader reader = command.ExecuteReader();


                    // Step 6: Reading the data from returned data set

                    while (reader.Read()) // false if no data or end of data set
                    {
                        //Access data using reader['ColumnName']
                        Console.WriteLine($"{reader["EmployeeID"]}  {reader["LastName"]}");
                        // You have your data, you can return it back to user using JSON object
                        // LIST, Dictionary, Class, Array 


                    }
                    connection.close();  // To close the connection

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
