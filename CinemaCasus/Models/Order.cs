using System.Text;
using System.Text.Json;
using CinemaCasus.Behaviors;
using CinemaCasus.Interfaces;

namespace SOA3_BioscoopCasus.Models
{
    public class Order
    {
        private int OrderNr { get; }

        private List<MovieTicket> Tickets { get;}
        
        private IPriceCalculationBehaviour PriceCalculationBehaviour { get; set; }

        public Order(int orderNr)
        {
            Tickets = new List<MovieTicket>();
            OrderNr = orderNr;
            this.PriceCalculationBehaviour = new NormalPriceCalculation();
        }
        
        public void SetPriceCalculationBehaviour(IPriceCalculationBehaviour priceCalculationBehaviour)
        {
            this.PriceCalculationBehaviour = priceCalculationBehaviour;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            this.Tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            if(Tickets.Count == 0)
            {
                return 0;
            }
            
            double orderPrice = PriceCalculationBehaviour.CalculatePrice(Tickets);
            
            return CalculateGroupDiscount(6, orderPrice, 0.9);
        }

        private double CalculateGroupDiscount(int minimumSize, double price, double discountPercentage)
        {
            if(Tickets.Count >= minimumSize)
            {
                price *= discountPercentage;
            }
            return price;
        }

        public override string ToString()
        {
            if(Tickets.Count== 0)
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


        private string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public void Export(TicketExportFormat format)
        {
            const string filePath = "../../../Files/Order.txt";
            
            switch (format)
            {
                case TicketExportFormat.PLAINTEXT:
                    File.WriteAllText(filePath, this.ToString());
                    break;
                case TicketExportFormat.JSON:
                    File.WriteAllText(filePath, this.ToJson());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }
    }
}
