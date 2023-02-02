﻿namespace SOA3_BioscoopCasus.Models
{
    public class MovieScreening
    {
        public DateTime DateAndTime { get; }
        public double PricePerSeat { get; }
        public Movie Movie { get; }

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.Movie = movie;
            this.DateAndTime = dateAndTime;
            this.PricePerSeat = pricePerSeat;
        }

        public int GetDayNumber()
        {
            return (int)DateAndTime.DayOfWeek;
        }
        
        public override string ToString()
        {
            return Movie.ToString()+PricePerSeat;
        }
    }
}
