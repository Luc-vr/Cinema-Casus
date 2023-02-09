using CinemaCasus.Interfaces;

namespace CinemaCasus.Behaviors.State
{
    internal class CompletedState : NonUpdateableStateClass
    {
        public override IState Submit()
        {
            Console.WriteLine("Already submitted");
            return new SubmittedState();
        }
    }
}
