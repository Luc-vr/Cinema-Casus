using CinemaCasus.Models;

namespace CinemaCasus.Interfaces
{
    public interface IState 
    {
        bool IsUpdateable();
        string GetState();
        IExportBehaviour SetExportBehaviour(IExportBehaviour newExportBehaviour, IExportBehaviour currentExportBehaviour);
        IPriceCalculationBehaviour SetPriceCalculationBehaviour(IPriceCalculationBehaviour priceCalculationBehaviour);
        MovieTicket AddSeatReservation(MovieTicket ticket);
        IExportBehaviour SetExportBehaviour(IExportBehaviour newExportBehaviour);
        IState Submit();
        IState Pay();
        IState Cancel();
    }
}
