using labbb3.Library.Data;
using labbb3.Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace labbb3.Library
{
    public static class DbContextTestHelper
    {
        public static int AddEntities()
        {
            using var context = new MovieDbContext();

            var director1 = new Director { FirstName = "Christopher", LastName = "Nolan" };
            var director2 = new Director { FirstName = "Steven", LastName = "Spielberg" };

            var movie1 = new Movie
            {
                Title = "Inception",
                ReleaseYear = 2010,
                Director = director1,
            };

            var movie2 = new Movie
            {
                Title = "Jurassic Park",
                ReleaseYear = 1993,
                Director = director2,
            };

            context.Movies.Add(movie1);
            context.Movies.Add(movie2);

            return context.SaveChanges();
        }

        public static int UpdateEntities()
        {
            using var context = new MovieDbContext();

            var movieToUpdate = context.Movies.FirstOrDefault(m => m.Title == "Inception");
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = "Inception (Updated)";

                return context.SaveChanges();
            }

            return 0;
        }

        public static IEnumerable<Movie> ReadEntities()
        {
            using var context = new MovieDbContext();
            return context.Movies
                          .Include(m => m.Director)
                          .ToList();
        }

        public static int RemoveEntities()
        {
            using var context = new MovieDbContext();

            var movieToRemove = context.Movies.FirstOrDefault(m => m.Title == "Inception (Updated)");
            if (movieToRemove != null)
            {
                context.Movies.Remove(movieToRemove);

                return context.SaveChanges();
            }

            return 0;
        }
    }
}
