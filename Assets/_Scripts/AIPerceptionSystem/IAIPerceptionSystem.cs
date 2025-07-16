using System;
using ringo.AIPerception;
using ringo.AIPerception.Senses;

namespace ringo.AIPerceptionSystem
{
    public interface IAIPerceptionSystem
    {
        public void RegisterSense<T>(IAIPerception perception) where T : IAISense;
        // TODO: Rename to senseType, type is too generic
        public void RegisterSense(Type type, IAIPerception perception);

        public void UnregisterSense<T>(IAIPerception perception) where T : IAISense;
        public void UnregisterSense(Type type, IAIPerception perception);


        public void Alert<T>(IPerceptionData perceptionData) where T : IAISense;
        public void Alert(Type type, IPerceptionData perceptionData);
    }
}