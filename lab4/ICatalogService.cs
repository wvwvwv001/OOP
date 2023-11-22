namespace Project1.Library;

    internal interface ICatalogService
    {
        int AddMovie(Movie movie);
        int AddDirector(Director director);

        int UpdateMovie(int movieId, string updatedTitle);
        int UpdateDirector(int directorId, string updatedFirstName, string updatedLastName);

        Movie ReadMovie(int movieId);
        Director ReadDirector(int directorId);

        int RemoveMovie(int movieId);
        int RemoveDirector(int directorId);
    }