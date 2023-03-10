namespace SOA3_BioscoopCasus.Models
{
    public class Movie
    {
        public string Title { get; }

        public List<MovieScreening> MovieScreenings = new();

        public Movie(string title)
        {
            this.Title = title;
        }

        public void AddScreening(MovieScreening screening)
        {
            MovieScreenings.Add(screening);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}