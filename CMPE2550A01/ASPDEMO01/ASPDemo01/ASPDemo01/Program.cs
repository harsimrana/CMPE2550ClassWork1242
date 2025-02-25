namespace ASPDemo01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("for debugging purpose");

            // WebApplication is a special class provided by MicroSoft:
            // used to configure the HTTP Pipeline and routes
            
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // MapGet will handle all GET requests from client side
            // Form submits may be used for GET request
            // Simple Lamda statements are used below for demo purpose only
            //Default 
            app.MapGet("/", () => "ASP.NET CORE Demo 01");

            //Specific end points are possible
            app.MapGet("/Special", () => "When you ask for something special, I will provide it you.");


            // Specific end point for processing form
            // 
            app.MapGet("/registerGet", (string getName, string getAge) => 
            $"Client Data: {getName}'s age is {getAge}");


            // Specific end point for processing form
            // Omne would think that passing for POST would be the same as the GET, one might be wrong
            app.MapPost("/registerPost", (string postName, string postAge) =>
            $"Client Data: {postName}'s age is {postName}");

            // AJAX Calls

            app.Run();  // Running your app
        }
    }
}
