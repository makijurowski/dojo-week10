using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieAPI
{
    public class WebRequest
    {
        // The second parameter is a function that returns a Dictionary of string keys to object values.
        // If an API returned an array as its top level collection the parameter type would be "Action>"
        public static async Task GetMovieDataAsync(string search, Action<Dictionary<string, dynamic>> Callback)
        {
            // Create a temporary HttpClient connection.
            string api_key = "0bb2c3e474013549eeeaa52f4bbad524";
            using (var Client = new HttpClient())
            {
                try
                {
                    Client.BaseAddress = new Uri($"https://api.themoviedb.org/3/search/movie?api_key={api_key}&query=\"{search}\"");
                    HttpResponseMessage Response = await Client.GetAsync(""); // Make the actual API call.
                    Response.EnsureSuccessStatusCode(); // Throw error if not successful.
                    string StringResponse = await Response.Content.ReadAsStringAsync(); // Read in the response as a string.

                    // Then parse the result into JSON and convert to a dictionary that we can use.
                    // DeserializeObject will only parse the top level object, depending on the API we may need to dig deeper and continue deserializing
                    
                    // ORIGINAL: Dictionary<string, object> JsonResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(StringResponse);

                    JObject tokens = JObject.Parse(StringResponse);
                    JArray resultsFromAPI = (JArray)tokens.SelectToken("results");

                    var Movie = resultsFromAPI[0];

                    Dictionary<string, dynamic> JsonResponse = new Dictionary<string, dynamic>
                    {
                        {"movie_name", (string)Movie["title"]},
                        {"rating", (decimal)Movie["vote_average"]},
                    };

                    // Finally, execute our callback, passing it the response we got.
                    Callback(JsonResponse);
                }
                catch (HttpRequestException e)
                {
                    // If something went wrong, display the error.
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}