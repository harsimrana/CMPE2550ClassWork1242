using EFDemo01.Models;

namespace EFDemo01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "EF Demo 01");


            // Entity Framework is Object -relation mapper

            // 1.Step - install Microsoft.EntityFrameworkCore.SqlServer package
            // 2. Step install tools - NuGet pacakage Manager- Package Manager console
            // install-package Microsoft.EntityFrameworkCore.Tools

            app.MapGet("/RetData", () =>
            {
                Console.WriteLine("Inside Ret Data Endpoint");
                // Entrire DB 
                using (var db = new DemoDb2550NorthwindContext())
                {
                    // Query style of LINQ queries

                    //Part 1
                    // UNCOMMENT THE FOLLOWING TO TEST IT WITH QUERY STYLE
                    //select * from products

                   /*
                        var results = from p in db.Products
                                      join c in db.Categories
                                        on p.CategoryId equals c.CategoryId
                                      where p.ProductId <= 10  // filtering results
                                      orderby p.ProductId descending  // sorting - by default it is ascending use keyword descending
                                      //select p;  // similar to select * 
                                      select new { p, c.CategoryName};  // Target specific columns 

                        return results.ToList();
                   */

                    //Part 2
                    // Method Style
                    // UNCOMMENT THE FOLLOWING TO TEST IT WITH Method STYLE of LINQ queries
                
                    var results = //db.Products.Select(x => x);  // Select * from Products
                                    db.Products
                                     .Where(x=> x.CategoryId == x.Category.CategoryId)
                                     .Where(x=> x.ProductId <= 10)  // Filtering the results
                                     //.OrderBy(x=>x.ProductId)  // SORTING - ascending order
                                     .OrderByDescending(x=>x.ProductId) // decending order - specific function for each one
                                     .Select(x => new { x.ProductId, x.ProductName, x.Category.CategoryName});
                    return results.ToList();
               

                }



            });

            app.Run();
        }
    }
}
