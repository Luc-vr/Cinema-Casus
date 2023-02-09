using CinemaCasus.Models;

namespace CinemaCasus.Interfaces;

public interface IPriceCalculationBehaviour
{
    double CalculatePrice(List<MovieTicket> tickets);
}