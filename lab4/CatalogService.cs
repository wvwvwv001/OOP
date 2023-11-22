using Microsoft.EntityFrameworkCore;

namespace Project1.Library;
    internal class CatalogService : ICatalogService
    {
        private readonly IDbContextFactory<CatalogContext> _contextFactory;

        public CatalogService(IDbContextFactory<CatalogContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public int AddMovie(Movie movie)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Movies.Add(movie);
            return context.SaveChanges();
        }

        public int AddDirector(Director director)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Directors.Add(director);
            return context.SaveChanges();
        }

        public int UpdateMovie(int movieId, string updatedTitle)
        {
            using var context = _contextFactory.CreateDbContext();
            var movie = context.Movies.Find(movieId);
            if (movie != null)
            {
                movie.Title = updatedTitle;
                context.Movies.Update(movie);
                return context.SaveChanges();
            }
            return 0;
        }

        public int UpdateDirector(int directorId, string updatedFirstName, string updatedLastName)
        {
            using var context = _contextFactory.CreateDbContext();
            var director = context.Directors.Find(directorId);
            if (director != null)
            {
                director.FirstName = updatedFirstName;
                director.LastName = updatedLastName;
                context.Directors.Update(director);
                return context.SaveChanges();
            }
            return 0;
        }

        public Movie ReadMovie(int movieId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Movies.Find(movieId);
        }

        public Director ReadDirector(int directorId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Directors.Find(directorId);
        }

        public int RemoveMovie(int movieId)
        {
            using var context = _contextFactory.CreateDbContext();
            var movie = context.Movies.Find(movieId);
            if (movie != null)
            {
                context.Movies.Remove(movie);
                return context.SaveChanges();
            }
            return 0;
        }

        public int RemoveDirector(int directorId)
        {
            using var context = _contextFactory.CreateDbContext();
            var director = context.Directors.Find(directorId);
            if (director != null)
            {
                context.Directors.Remove(director);
                return context.SaveChanges();
            }
            return 0;
        }
    }