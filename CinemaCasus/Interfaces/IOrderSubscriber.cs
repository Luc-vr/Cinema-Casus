using CinemaCasus.Models;

namespace CinemaCasus.Interfaces;

public interface IOrderSubscriber
{
    void Update(Order order);
}