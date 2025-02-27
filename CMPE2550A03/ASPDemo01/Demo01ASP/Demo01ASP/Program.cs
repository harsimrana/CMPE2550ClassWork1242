namespace Demo01ASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // WebApplication is a special class which is provided by MICROSOFT
            // used to configure HTTP pipeline and routes

            var builder = WebApplication.CreateBuilder(args);
            
            var app = builder.Build();


            //MapGet handles all GET request coming from client side
            // Form submits may be used for GET requests
            // Simple lamda statements are used below for demo purpose only
            // Default endpoint
            app.MapGet("/", () => "ASP DEMO 01");

            //Specific end point
            app.MapGet("/special", () => "When you ask for something special, I will provide it to you");


            // form processing with GET
            app.MapGet("/registerGet", (string getName, string getAge) => $"Form processing {getName} is {getAge} years old;");

            // One would think that passing for POST would be same as the GET, one would be wrong

            // form processing with POST
            app.MapPost("/registerPost", (string postName, string postAge) => $"Form processing {postName} is {postAge} years old;");

            //AJAX call


            app.Run();
        }
    }
}
