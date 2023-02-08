using CinemaCasus.Interfaces;
using SOA3_BioscoopCasus.Models;

namespace CinemaCasus.Behaviors.PriceCalculation;

public class StudentPriceCalculation : IPriceCalculationBehaviour
{
    public double CalculatePrice(List<MovieTicket> tickets)
    {
        const double premiumPrice = 2;

        double orderPrice = 0;
        for (int i = 0; i < tickets.Count; i++)
        {
            if (i % 2 != 0) continue;
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