using MovieAppLayered.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppLayered.Controller;
using MovieAppLayered.Services;

namespace MovieAppLayered.Presentation
{
    internal class MovieStore
    {
        static MovieManager manager;
        public static void DesearilizeMovies()
        {
            manager = new MovieManager();
            Console.WriteLine("Movies are Deserealized now!");
        }
        public static void DisplayMenu()
        {
            manager=new MovieManager();
            while (true)
            {

                Console.WriteLine("Welcome to Movie App\nWhat do u wish to do: \n");
                Console.WriteLine("1. Display All Movies. ");
                Console.WriteLine("2. Display Movie by Movie Id.");
                Console.WriteLine("3. Add Movies.");
                Console.WriteLine("4. Clear All Movies at once.");
                Console.WriteLine("5. Clear a movie by movie id.");
                Console.WriteLine("6. Edit Movie");
                Console.WriteLine("7. Serialize then exit");
                Console.WriteLine("8. Desearilize.");
                Console.WriteLine();
                int choice = Convert.ToInt32(Console.ReadLine());

                DoTasks(choice);
            }
        }
        public static void DoTasks(int choice)
        {
            switch (choice)
            {
                case 1:
                    DisplayAllMovies();
                    break;
                case 2:
                    DisplayMovieById();
                    break;
                case 3:
                    CreateMovie();
                    break;
                case 4:
                    ClearAllMoviesAtOnce();
                    break;
                case 5:
                    ClearMovie();
                    break;
                case 6:
                    EditMovie();
                    break;
                case 7:
                    SerializeMoviesBeforeExit();
                    Environment.Exit(0);
                    break;
                case 8:
                    DeserializeMovies();
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
        public static void EditMovie()
        {
            Console.WriteLine("Enter Movie Id to edit: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            var movie = manager.GetMovieById(movieId);

            if (movie != null)
            {
                Console.WriteLine("Enter new Movie Name: ");
                string movieName = Console.ReadLine();
                Console.WriteLine("Enter new Movie Genre: ");
                string movieGenre = Console.ReadLine();
                Console.WriteLine("Enter new Movie Year: ");
                int movieYear = Convert.ToInt32(Console.ReadLine());

                manager.UpdateMovie(movieId, movieName, movieGenre, movieYear);
                Console.WriteLine("Movie updated successfully!");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
        }
        public static void DisplayAllMovies()
        {
            var movies = MovieManager.GetAllMovies();
            bool anyMovieExists = false;
            foreach (var movie in movies)
            {
                if (movie != null)
                {
                    Console.WriteLine(movie);
                    anyMovieExists = true;
                }
            }
            if (!anyMovieExists) Console.WriteLine("No movies found.");
        }
        public static void DisplayMovieById()
        {
            Console.WriteLine("Enter Movie Id: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            var movie = manager.GetMovieById(movieId);
            if (movie != null)
            {
                Console.WriteLine(movie);
                return;
            }
            Console.WriteLine("Movie not found.");
            
        }
        public static void CreateMovie()
        {
            var movies = MovieManager.GetAllMovies();
            if (movies.All(m => m != null))
            {
                Console.WriteLine("5 input array objects are already filled, no more inputs can be taken.");
                return;
            }
            Console.WriteLine("Enter Movie Id: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Movie Name: ");
            string movieName = Console.ReadLine();
            Console.WriteLine("Enter Movie Genre: ");
            string movieGenre = Console.ReadLine();
            Console.WriteLine("Enter Movie Year: ");
            int movieYear = Convert.ToInt32(Console.ReadLine());

            manager.Create(movieId, movieName, movieGenre, movieYear);
        }
        public static void ClearAllMoviesAtOnce()
        {
            manager.ClearAllMovies();
        }
        public static void ClearMovie()
        {
            Console.WriteLine("Enter Movie Id to clear: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            manager.ClearMovieById(movieId);
        }
        public static void DeserializeMovies()
        {
            manager = new MovieManager();
            Console.WriteLine("Deserialization completed!");
        }
        public static void SerializeMoviesBeforeExit()
        {
            MovieSerializer.Serialize(MovieManager.GetAllMovies());
        }
    }

}
