using System;
using System.Collections.Generic;
using ringo.AIPerception;
using ringo.AIPerception.Senses;

namespace ringo.AIPerceptionSystem
{
    public class AIPerceptionSystem : IAIPerceptionSystem
    {
        private Dictionary<Type, List<IAIPerception>> _perceptionSenses = new();

        public void RegisterSense(IPerceptionSense sense, IAIPerception perception)
        {
            var senseType = sense.GetType();

            if (!_perceptionSenses.ContainsKey(senseType))
                _perceptionSenses[senseType] = new List<IAIPerception>();

            _perceptionSenses[senseType].Add(perception);
        }

        public void UnregisterSense(IPerceptionSense sense, IAIPerception perception)
        {
            var senseType = sense.GetType();

            if (!_perceptionSenses.ContainsKey(senseType))
                return;

            _perceptionSenses[senseType].Remove(perception);

            // No perception senses left for this sense, remove it from the dictionary.
            if (_perceptionSenses[senseType].Count == 0)
            {
                _perceptionSenses.Remove(senseType);
            }
        }

        public void Alert<T>(IPerceptionData perceptionData) where T : IPerceptionSense
        {
            foreach (var sense in _perceptionSenses[typeof(T)])
            {
                sense.NotifyPerceptionEvent<T>(perceptionData);
            }
        }
    }
}