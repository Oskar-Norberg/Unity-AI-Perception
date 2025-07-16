using ringo.AIPerception;
using ringo.AIPerception.Senses;

namespace ringo.AIPerceptionSystem
{
    public interface IAIPerceptionSystem
    {
        public void RegisterSense(IPerceptionSense sense, IAIPerception perception);
        public void UnregisterSense(IPerceptionSense sense, IAIPerception perception);

        public void Alert<T>(IPerceptionData perceptionData) where T : IPerceptionSense;
    }
}