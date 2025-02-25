namespace ASPDEMO01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("For Debugging purpose");
            // Webapplication is a special class provided by Microsoft: 
            // used to configre the HTTP Pipeline and routes
            
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();


            // MapGet handles all GET requests receieved from client side.
            // Form submits may be used for GET requests
            // Simple lamda statements are used below for demo purpose only
            
            // Default End point
            app.MapGet("/", () => "ASP DEMO 01");

            //Specific end point 
            app.MapGet("/special", () => "When you ask for something special, I will provide it to you.");

            // End point for Form submission
            app.MapGet("/registerGet", (string getFirst, string getColor, string getAge) => 
            $" Client Data: {getFirst}'s Favourite Color is {getColor} and he/she/they is/are {getAge} years old.");


            //End point for Form submission with POST
            //One would think that passing for POST would be the same as the GET, but one would be wrong

            /*app.MapPost("/registerPost", (string postFirst, string postColor, string postAge) =>
            $" Client Data: {postFirst}'s Favourite Color is {postColor} and he/she/they is/are {postAge} years old.");
            */
            // AJAX calls


            /*app.MapPost("/registerPost", ( ) =>
            $" Client Data: {postFirst}'s Favourite Color is {postColor} and he/she/they is/are {postAge} years old.");
            */

            app.Run();  // running the app
        }

        record class Info(string postFirst, string postColor, string postAge);
        // keyword  class is optional here
    }
}
