using System.Text;
using System.Text.Json;

namespace SOA3_BioscoopCasus.Models
{
    public class Order
    {
        private int OrderNr { get; }
        private bool IsStudentOrder { get; }

        private List<MovieTicket> Tickets { get;}

        public Order(int orderNr, bool isStudentOrder)
        {
            Tickets = new List<MovieTicket>();
            OrderNr = orderNr;
            this.IsStudentOrder = isStudentOrder;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            this.Tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            if(Tickets == null || Tickets.Count == 0)
            {
                return 0;
            }
            double orderPrice = 0;
            double premiumPrice = 3;
            if (IsStudentOrder)
            {
                premiumPrice = 2;
            }
            bool isWeekDay = Tickets[0].IsScreeningWeekday();

            // If it is a weekday or a student order, the second ticket is free
            bool secondTicketFree = (IsStudentOrder || isWeekDay);

            for (int i = 0; i < Tickets.Count; i++)
            {
                if (secondTicketFree && i % 2 != 0) continue;
                double ticketPrice = Tickets[i].GetPrice();
                if (Tickets[i].IsPremium)
                {
                    ticketPrice += premiumPrice;
                }
                orderPrice += ticketPrice;
            }
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
