

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
                    string query = "select * from Employees where EmployeeId = @empId";

                    //Step 4: Execute SQl query directly from C# code
                    // SqlCommand class object is required
                    // Need to pass query and connection object
                                                // Query , connection object
                    SqlCommand command = new SqlCommand(query, connection);

                    //Hard coded the value, but you can use your value coming from client side
                    command.Parameters.AddWithValue("@empId", 3);

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

          
                    connection.Close();  // To close the connection


                    // Test it with Stored Procedure
                    /*
                     * Step 1: Create a stored procedure in the DB
                     * Step 2: Call your Stored Procedure 
                     * 
                     */

                    /* Stored Procedure Definition: Make  Sure to create it in your DB
                        create procedure GetEmployees (@P_EmpId int)
                        as
	                        select * from Employees
	                        where EmployeeID = @P_EmpId

                        go
                     */

                    connection.Open();

                    Console.WriteLine("Tesing it with Stored Procedure");

                    query = "GetEmployees";  // name of SP as query

                    command = new SqlCommand(query, connection);

                    //Change the command type to SP
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Make sure to add arguments
                    command.Parameters.AddWithValue("@P_EmpId", 5);

                    // Run your SP
                    reader = command.ExecuteReader();


                    // Step 6: Reading the data from returned data set

                    while (reader.Read()) // false if no data or end of data set
                    {
                        //Access data using reader['ColumnName']
                        Console.WriteLine($"{reader["EmployeeID"]}  {reader["LastName"]}");
                        // You have your data, you can return it back to user using JSON object
                        // LIST, Dictionary, Class, Array 


                    }


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
