using CinemaCasus.Interfaces;
using SOA3_BioscoopCasus.Models;

namespace CinemaCasus.Behaviors;

public class NormalPriceCalculation : IPriceCalculationBehaviour
{
    public double CalculatePrice(List<MovieTicket> tickets)
    {
        const double premiumPrice = 3;

        bool isWeekDay = tickets[0].IsScreeningWeekday();

        double orderPrice = 0;
        for (int i = 0; i < tickets.Count; i++)
        {
            if (isWeekDay && i % 2 != 0) continue;
            double ticketPrice = tickets[i].GetPrice();
            if (tickets[i].IsPremium)
            {
                ticketPrice += premiumPrice;
            }

            orderPrice += ticketPrice;
        }
        
        return orderPrice;
    }
}