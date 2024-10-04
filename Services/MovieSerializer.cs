using MovieAppLayered.Models;
using System.IO;
using System.Text.Json;
using System.Configuration;

namespace MovieAppLayered.Services
{
    internal class MovieSerializer
    {
        static string filePath = ConfigurationManager.AppSettings["filePath"];
        public static void Serialize(Movie[] movies)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(JsonSerializer.Serialize(movies));

            }
            Console.WriteLine("Serealization successful!");
        }
        public static Movie[] Deserialize()
        {
            if (!File.Exists(filePath))
            {
                return new Movie[5];
            }
            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = sr.ReadToEnd();
                Movie[] movies = JsonSerializer.Deserialize<Movie[]>(json);
                return movies;
            }
        }
    }
}
