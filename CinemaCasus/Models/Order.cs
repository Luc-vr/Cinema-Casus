using CinemaCasus.Behaviors.Export;
using CinemaCasus.Behaviors.PriceCalculation;
using CinemaCasus.Behaviors.State;
using CinemaCasus.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace CinemaCasus.Models
{
    public class Order : IOrder
    {
        [JsonProperty]
        private int OrderNr { get; }

        [JsonProperty]
        private List<MovieTicket> Tickets { get; }

        private IState State { get; set; }
        private IPriceCalculationBehaviour PriceCalculationBehaviour { get; set; }

        private IExportBehaviour ExportBehaviour { get; set; }

        public Order(int orderNr)
        {
            Tickets = new List<MovieTicket>();
            OrderNr = orderNr;
            this.PriceCalculationBehaviour = new NormalPriceCalculation();
            this.ExportBehaviour = new ExportOrderToPlainText();
            this.State = new CreatedState();
        }

        public void SetPriceCalculationBehaviour(IPriceCalculationBehaviour priceCalculationBehaviour)
        {
            try
            {
                this.PriceCalculationBehaviour = State.SetPriceCalculationBehaviour(priceCalculationBehaviour);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SetExportBehaviour(IExportBehaviour exportBehaviour)
        {
            try
            {
                this.ExportBehaviour = this.State.SetExportBehaviour(exportBehaviour, this.ExportBehaviour);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            try
            {
                this.Tickets.Add(this.State.AddSeatReservation(ticket));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public double CalculatePrice()
        {
            if (Tickets.Count == 0)
            {
                return 0;
            }
            double orderPrice = PriceCalculationBehaviour.CalculatePrice(Tickets);
            return CalculateGroupDiscount(6, orderPrice, 0.9);
        }

        private double CalculateGroupDiscount(int minimumSize, double price, double discountPercentage)
        {
            if (Tickets.Count >= minimumSize)
            {
                price *= discountPercentage;
            }
            return price;
        }

        public override string ToString()
        {
            if (Tickets.Count == 0)
            {
                return "No tickets found";
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Order number: " + OrderNr);
            stringBuilder.AppendLine("Movie: " + Tickets[0].MovieScreening.Movie.ToString());
            stringBuilder.AppendLine("On: " + Tickets[0].MovieScreening.DateAndTime.ToString("dddd dd-MM-yyyy"));
            stringBuilder.AppendLine("Movie starts at: " + Tickets[0].MovieScreening.DateAndTime.ToString("H:mm"));
            stringBuilder.AppendLine();

            foreach (MovieTicket ticket in Tickets)
            {
                stringBuilder.AppendLine(ticket.ToString());
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Total price: " + CalculatePrice());

            return stringBuilder.ToString();
        }

        public void Export()
        {
            const string filePath = "../../../Files/Order.txt";
            File.WriteAllText(filePath, this.ExportBehaviour.Export(this));
        }

        public void Submit()
        {
            try
            {
                this.State = this.State.Submit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Cancel()
        {
            try
            {
                this.State = this.State.Cancel();   
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Pay()
        {
            try
            {
                this.State = this.State.Pay();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}