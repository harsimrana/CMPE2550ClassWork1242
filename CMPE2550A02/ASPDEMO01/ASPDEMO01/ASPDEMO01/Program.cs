using System.Text.RegularExpressions;

namespace ASPDEMO01
{
    public class Program
    {
        /**************************************************
         * Function Name    : CleanInputs
         * Purpose          : To sanitize the input
         * input            : string 
         * Output           : string - Cleaned Input
         * ****************************************************/
        public static string CleanInputs(string input)
        {
            // Clean your inputs
            string cleanInput = Regex.Replace(input.Trim(), "<.*?>|&.*?;", string.Empty);

            return cleanInput;
        }
        public static void Main(string[] args)
        {
            
            Console.WriteLine("For Debugging purpose");
            // Webapplication is a special class provided by Microsoft: 
            // used to configre the HTTP Pipeline and routes
            
            var builder = WebApplication.CreateBuilder(args);
            // CORS issue 
            builder.Services.AddControllers();

            var app = builder.Build();

            // without CORS services will fail upon attempted activation/ missing AddCors() internal exception

            // Need to fix CORS problem encountered with POST AJAX request
            // will allow web service to be called from any website

            app.UseCors(x => 
                            x.AllowAnyMethod()
                             .AllowAnyHeader()
                             .SetIsOriginAllowed(origin => true));

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

            // This one is for simple Lamda expression
            /* app.MapPost("/registerPost", (Info sub) =>
             $" Client Data: {sub.postFirst}'s Favourite Color is {sub.postColor} and he/she/they is/are {sub.postAge} years old.");
             */

            // Something Complex

            app.MapPost("/registerPost", (Info sub) =>
            {
                // Processing here
                Console.WriteLine("Inside register Post endpoint");
                int charCount = sub.postFirst.Length;
                // valdiation and sanitize  


                // HTML response back to client -- Uncomment the following line
                //return $" Hello {sub.postFirst} you have {charCount} letters in your name";

                // JSON response back to client -- Uncomment the following line

                var response = new
                {
                    status = "success",
                    Count = charCount
                };

                return response;

            });

            app.Run();  // running the app
        }

        record class Info(string postFirst, string postColor, string postAge);
        // keyword  class is optional here
    }
}
