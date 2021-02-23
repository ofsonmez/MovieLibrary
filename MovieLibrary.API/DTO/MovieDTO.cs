namespace MovieLibrary.API.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DirectorDTO Director { get; set; }
    }
}