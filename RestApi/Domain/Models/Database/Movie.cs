namespace Domain.Model.DataBase
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime YearOfRelease { get; set; }
        public string Plot { get; set; }
        public int Producer { get; set; }
        public string Poster { get; set; }
    }
}