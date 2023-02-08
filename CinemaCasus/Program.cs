using SOA3_BioscoopCasus.Models;

Movie movie = new Movie(title: "GeniusMovieTitle");
MovieScreening screening = new MovieScreening(movie, DateTime.Now.AddDays(2), 6.5);
bool isPremium = true;
bool isNotPremium = false;
bool isStudentOrder = false;



MovieTicket ticket = new MovieTicket(screening, isNotPremium, 1, 1);
MovieTicket ticket2 = new MovieTicket(screening, isNotPremium, 1, 1);
MovieTicket ticket3 = new MovieTicket(screening, isPremium, 1, 1);
MovieTicket ticket4 = new MovieTicket(screening, isPremium, 1, 1);

Order order = new Order(1, isStudentOrder);

order.AddSeatReservation(ticket);
order.AddSeatReservation(ticket2);
order.AddSeatReservation(ticket3);
Console.WriteLine(order.CalculatePrice());
order.Export(TicketExportFormat.PLAINTEXT);