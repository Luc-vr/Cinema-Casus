using CinemaCasus.Interfaces;

namespace CinemaCasus.Models;

public class Customer : IOrderSubscriber
{
    public string FullName { get; }
    public string Email { get; }
    public string PhoneNumber { get; }
    
    public NotificationMethod NotificationMethod { get; }
    
    public void Update(Order order)
    {
        Console.WriteLine($"Customer {FullName} has been notified of order {order.OrderNr} through {NotificationMethod}");
        // TODO: Call adapter to send notification to customer (adapter pattern)
    }

    public Customer(string fullName, string email, string phoneNumber, NotificationMethod notificationMethod = NotificationMethod.Email)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        NotificationMethod = notificationMethod;
    }
    
    public override string ToString()
    {
        return $"Name: {FullName}, Email: {Email}, Phone number: {PhoneNumber}";
    }

}