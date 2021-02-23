using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieLibrary.Core.Models
{
    public class Director
    {
        public Director()
        {
            Movies = new Collection<Movie>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}