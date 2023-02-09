namespace CinemaCasus.Models
{
    public class MovieTicket
    {
        private int RowNr { get; }
        private int SeatNr { get; }
        public bool IsPremium { get; }
        public MovieScreening MovieScreening { get; }


        public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
        {
            MovieScreening = movieScreening;
            IsPremium = isPremiumReservation;
            SeatNr = seatNr;
            RowNr = seatRow;
        }

        public bool IsScreeningWeekday()
        {
            //checks if day comes before friday
            return MovieScreening.GetDayNumber() < 4;
        }

        public double GetPrice()
        {
            return MovieScreening.PricePerSeat;
        }

        public override string ToString()
        {
            return "You are seated at row " + RowNr + ", seat " + SeatNr;
        }

        public string GetMovieTitle()
        {
            return MovieScreening.Movie.Title;
        }
    }
}