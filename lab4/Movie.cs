namespace Project1.Library;
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public Director Director { get; set; }
        public int DirectorId { get; set; }
    }