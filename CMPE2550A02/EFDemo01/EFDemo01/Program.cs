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
                                     .Where(x => x.CategoryId == x.Category.CategoryId)
                                     .Where(x => x.ProductId <= 10)  // Filtering the results
                                                                     //.OrderBy(x=>x.ProductId)  // SORTING - ascending order
                                     .OrderByDescending(x => x.ProductId) // decending order - specific function for each one
                                     .Select(x => new { x.ProductId, x.ProductName, x.Category.CategoryName });
                    return results.ToList();


                }



            });

            // DML PART -INSERT, UPDATE AND DELETE
            // For testing purpose using MapGet only- make sure to use REST methods
            app.MapGet("InsertCategory", () =>
            {
                Console.WriteLine("Inside Insert Category");

                var db = new DemoDb2550NorthwindContext();

                // Create an object of category class

                Category newCategory = new Category();

                // Populate the values for the required properties

                newCategory.CategoryName = "NewTest";
                newCategory.Description = "New Desc";

                try
                {
                    // using add method you can add a new object into the list
                    db.Categories.Add(newCategory);

                    // Save the changes in the DB
                    db.SaveChanges(); // == Commit
                                      // 
                    Console.WriteLine("Inserted successfully");
                    return "Inserted Successfully";


                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);

                    return "Error " + e.Message;
                }
            });

            app.MapGet("DeleteCategory/{cid}", (string cid) =>
            {
                Console.WriteLine($" Inside delete Category {cid}");
                try
                {
                    int categoryId = int.Parse(cid);

                    var db = new DemoDb2550NorthwindContext();

                    //Try to delete category form DB
                    if (db.Categories.Find(categoryId) is Category c)
                    { // if match found, it will return an object
                        // Remove that oject from LIST

                        db.Categories.Remove(c);
                        db.SaveChanges();

                        return "Deleted successfully";
                    }
                    else
                    {
                        return $"Category with id {categoryId} is not found";
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);

                    return "Error " + e.Message;
                }

            });

            app.MapGet("UpdateCategory/{cid}/{cname}", (string cid, string cname) =>
            {
                Console.WriteLine($" Inside Update Category {cid}");
                try
                {
                    int categoryId = int.Parse(cid);

                    var db = new DemoDb2550NorthwindContext();

                    //Try to Update category form DB
                    if (db.Categories.Find(categoryId) is Category c)
                    { // if match found, it will return an object
                        // Update that oject from LIST

                        // Now you have object you can make changes

                        c.CategoryName = cname; // New name
                        c.Description = "Testing with hard code value here";


                        db.Categories.Update(c);  // updating object in the list

                    
                        db.SaveChanges(); // saving changes 

                        return "Update successfully";
                    }
                    else
                    {
                        return $"Category with id {categoryId} is not found";
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);

                    return "Error " + e.Message;
                }

            });


            app.Run();
        }
    }
}
