using CinemaCasus.Interfaces;
using CinemaCasus.Models;

namespace CinemaCasus.Behaviors.State
{
    internal abstract class StateClass : IState
    {
        public virtual bool IsUpdateable()
        {
            return true;
        }

        public virtual MovieTicket AddSeatReservation(MovieTicket ticket)
        {
            return ticket;
        }

        public virtual IExportBehaviour SetExportBehaviour(IExportBehaviour newExportBehaviour)
        {
            return newExportBehaviour;
        }

        public virtual IState Submit()
        {
            return new SubmittedState();
        }

        public string GetState()
        {
            return GetType().Name;
        }

        public virtual IExportBehaviour SetExportBehaviour(IExportBehaviour newExportBehaviour, IExportBehaviour currentExportBehaviour)
        {
            return newExportBehaviour;
        }

        public virtual IPriceCalculationBehaviour SetPriceCalculationBehaviour(IPriceCalculationBehaviour priceCalculationBehaviour)
        {
            return priceCalculationBehaviour;
        }
        public virtual IState Pay()
        {
            return new CompletedState();
        }

        public virtual IState Cancel()
        {
            return new CancelledState();
        }

        protected static Exception NotUpdateableException()
        {
            Console.WriteLine("You can not update this order");
            return new Exception("You can not update this order");
        }
    }
}
