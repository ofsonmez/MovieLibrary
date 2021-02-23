using System.IO;

namespace MovieLibrary.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}