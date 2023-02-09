using CinemaCasus.Models;

namespace CinemaCasus.Interfaces
{
    public interface IOrder
    {
        void SetPriceCalculationBehaviour(IPriceCalculationBehaviour priceCalculationBehaviour);
        void AddSeatReservation(MovieTicket ticket);
        double CalculatePrice();
        string ToString();
        void Submit();
        void Cancel();
        void Pay();
    }
}
