using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppLayered.Models;
using MovieAppLayered.Services;

namespace MovieAppLayered.Controller
{
    internal class MovieManager
    {
        static Movie[] movies=new Movie[5];
        public MovieManager() {
            movies = MovieSerializer.Deserialize();
        }

        
        public void Create(int movieId, string movieName, string movieGenre, int movieYear)
        {
           
            if (movies.All(m => m != null))
            {
                Console.WriteLine("Movie list is full, no more movies can be added.\n");
                return;
            }

            var movie = new Movie(movieId, movieName, movieGenre, movieYear);
            for (int i = 0; i < movies.Length; i++)
            {
                if (movies[i] == null)
                {
                    movies[i] = movie;
                    Console.WriteLine("Movies added successfully!\n");
                    return;
                }
                
            }
        }

        public Movie GetMovieById(int movieId)
        {
            return movies.Where(m => m != null && m.MovieId == movieId).FirstOrDefault();
        }

        public static Movie[] GetAllMovies()
        {
            return movies;
        }

        public void ClearMovieById(int movieId)
        {
            for (int i = 0; i < movies.Length; i++)
            {
                if (movies[i] != null && movies[i].MovieId == movieId)
                {
                    movies[i] = null;
                    Console.WriteLine($"Movie with Id {movieId} cleared.\n");
                    return;
                }
            }
            Console.WriteLine($"Movie with Id {movieId} not found.\n");
        }
        public void UpdateMovie(int movieId, string movieName, string movieGenre, int movieYear)
        {
            for (int i = 0; i < movies.Length; i++)
            {
                if (movies[i] != null && movies[i].MovieId == movieId)
                {
                    movies[i].MovieName = movieName;
                    movies[i].MovieGenre = movieGenre;
                    movies[i].MovieYear = movieYear;
                    return;
                }
            }
            Console.WriteLine("Movie not found for update.\n");
        }
        public void ClearAllMovies()
        {
            for (int i = 0; i < movies.Length; i++)
            {
                movies[i] = null;
            }
            Console.WriteLine("All the movies have been cleared.\n");
        }
    }
}
