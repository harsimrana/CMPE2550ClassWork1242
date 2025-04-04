using EFDemo01.ModelNWD;

namespace EFDemo01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            /*
             EF- Entity Framework - is object relation mapper
               It is going to create classes for all tables in the Database
               Work with classes and objects  2300

                Step 01: Install Package - Microsoft.EntityFrameworkCore.SqlServer
                Step 02: Install a tool  Tools- NuGet package manger- Package Manager Console

                install-package Microsoft.EntityFrameworkCore.Tools   Make sure to add version if you are targerting any specific version
                
                Reverse Engineering part
                

             */

            app.MapGet("/RetData", () => {
                Console.WriteLine("Inside RetData Endpoint");

                // Create an object of DB
                var db = new DemoDb2550NorthwindContext();

                // LINQ queries 
                // Query Style of LINQ queries
                // PART 1
                //select * from Products
                //UNCOMMENT THE FOLLOWING TO TEST IT WITH QUERY STYLE

             /*    
                  var results = from p in db.Products
                                join c in db.Categories
                                    on p.CategoryId equals c.CategoryId
                                where p.ProductId <= 5 // Filtering
                                orderby p.ProductId descending  // By default it is ascending order use keyword descending for otherwise
                                        //select p; // Similar select *
                                    select new { p.ProductId, p.ProductName, c.CategoryName }; // Specific column

                  return results.ToList();
               */  
                  

                //Method Style
               
                var results = db.Products
                                 .Where(x=>x.CategoryId == x.Category.CategoryId) // JOIN
                                 .Where(x => x.ProductId <= 5)
                                 //.OrderBy(x=>x.ProductId) // Ascending
                                  .OrderByDescending(x=> x.ProductId)
                                   //.Select(x => x);  // Select * from Products
                                   .Select(x => new { x.ProductId, x.ProductName, x.Category.CategoryName });
                 return results.ToList();
                 

            });

            app.Run();
        }
    }
}
