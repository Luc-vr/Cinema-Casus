namespace CinemaCasus.Models
{
    public class MovieScreening
    {
        public DateTime DateAndTime { get; }
        public double PricePerSeat { get; }
        public Movie Movie { get; }

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            Movie = movie;
            DateAndTime = dateAndTime;
            PricePerSeat = pricePerSeat;
        }

        public int GetDayNumber()
        {
            return (int)DateAndTime.DayOfWeek;
        }

        public override string ToString()
        {
            return Movie.ToString() + PricePerSeat;
        }
    }
}
