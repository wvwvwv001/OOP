using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace labbb3.Library.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public Director Director { get; set; }
        public int DirectorId { get; set; }



    }
}
