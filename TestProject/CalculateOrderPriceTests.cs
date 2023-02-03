using SOA3_BioscoopCasus.Models;

namespace TestProject;

public class Tests
{
    private Movie movie;
    private MovieScreening weekendScreening;
    private MovieScreening nonWeekendScreening;
    private MovieTicket weekendPremiumTicket;
    private MovieTicket nonWeekendPremiumTicket;
    private MovieTicket weekendNonPremiumTicket;
    private MovieTicket nonWeekendNonPremiumTicket;
    private Order studentOrder;
    private Order nonStudentOrder;
    
    
    [SetUp]
    public void Setup()
    {
        this.movie = new Movie(title: "Test movie");
        this.weekendScreening = new (movie, new DateTime(2023, 02, 04), 6.5);
        this.nonWeekendScreening = new (movie, new DateTime(2023, 02, 01), 6.5);
        
        this.weekendPremiumTicket = new (weekendScreening, true, 1, 1);
        this.nonWeekendPremiumTicket = new (nonWeekendScreening, true, 1, 1);
        this.weekendNonPremiumTicket = new (weekendScreening, false, 1, 1);
        this.nonWeekendNonPremiumTicket = new (nonWeekendScreening, false, 1, 1);
        
        this.studentOrder = new (1, true);
        this.nonStudentOrder = new (1, false);
    }
    
    [Test]
    public void TestCase1()
    {
        // Test an order without tickets
        Assert.That(studentOrder.CalculatePrice(), Is.EqualTo(0));
    }
    
    [Test]
    public void TestCase2()
    {
        // Test an order with 2 tickets, no student order, in a weekend, premium seats
        nonStudentOrder.AddSeatReservation(weekendPremiumTicket);
        nonStudentOrder.AddSeatReservation(weekendPremiumTicket);
        Assert.That(nonStudentOrder.CalculatePrice(), Is.EqualTo(19));
    }
    
    [Test]
    public void TestCase3()
    {
        // Test an order with 2 tickets, no student order, in a weekend, no premium seats
        nonStudentOrder.AddSeatReservation(weekendNonPremiumTicket);
        nonStudentOrder.AddSeatReservation(weekendNonPremiumTicket);
        Assert.That(nonStudentOrder.CalculatePrice(), Is.EqualTo(13));
    }
    
    [Test]
    public void TestCase4()
    {
        // Test an order with 2 tickets, no student order, in a weekend, no premium seats
        nonStudentOrder.AddSeatReservation(nonWeekendNonPremiumTicket);
        nonStudentOrder.AddSeatReservation(nonWeekendNonPremiumTicket);
        Assert.That(nonStudentOrder.CalculatePrice(), Is.EqualTo(6.5));
    }
    
    [Test]
    public void TestCase5()
    {
        studentOrder.AddSeatReservation(weekendPremiumTicket);
        Assert.That(studentOrder.CalculatePrice(), Is.EqualTo(8.5));
    }
    
    [Test]
    public void TestCase6()
    {
        studentOrder.AddSeatReservation(weekendNonPremiumTicket);
        Assert.That(studentOrder.CalculatePrice(), Is.EqualTo(6.5));
    }
    
    [Test]
    public void TestCase7()
    {
        studentOrder.AddSeatReservation(nonWeekendNonPremiumTicket);
        studentOrder.AddSeatReservation(nonWeekendNonPremiumTicket);
        Assert.That(studentOrder.CalculatePrice(), Is.EqualTo(6.5));
    }
}