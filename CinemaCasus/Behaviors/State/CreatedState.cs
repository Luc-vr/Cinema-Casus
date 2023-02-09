using CinemaCasus.Interfaces;

namespace CinemaCasus.Behaviors.State
{
    internal class CreatedState : StateClass
    {
        public override IState Pay()
        {
            Console.WriteLine("Order needs to be submitted before you pay");
            return new CreatedState();
        }
    }
}
