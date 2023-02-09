using CinemaCasus.Interfaces;
using CinemaCasus.Models;

namespace CinemaCasus.Behaviors.State
{
    internal abstract class NonUpdateableStateClass : StateClass
    {
        public override MovieTicket AddSeatReservation(MovieTicket ticket)
        {
            throw NotUpdateableException();
        }

        public override IState Submit()
        {
            throw NotUpdateableException();
        }

        public override IState Pay()
        {
            throw NotUpdateableException();
        }

        public override IState Cancel()
        {
            throw NotUpdateableException();
        }

        public override IExportBehaviour SetExportBehaviour(IExportBehaviour newExportBehaviour)
        {
            throw NotUpdateableException();
        }

        public override IPriceCalculationBehaviour SetPriceCalculationBehaviour(IPriceCalculationBehaviour priceCalculationBehaviour)
        {
            throw NotUpdateableException();
        }
    }
}
