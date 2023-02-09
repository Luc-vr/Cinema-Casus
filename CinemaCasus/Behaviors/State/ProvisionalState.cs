using CinemaCasus.Interfaces;

namespace CinemaCasus.Behaviors.State
{
    internal class ProvisionalState : StateClass
    {
        public override IState Submit()
        {
            Console.WriteLine("Already submitted");
            return new SubmittedState();
        }
    }
}
