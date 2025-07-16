using System;
using System.Collections.Generic;
using ringo.AIPerception;
using ringo.AIPerception.Senses;
using ringo.AIStimuliSource;

namespace ringo.AIPerceptionSystem
{
    public class AIPerceptionSystem : IAIPerceptionSystem
    {
        private Dictionary<Type, List<IAIPerception>> _perceptionSenses = new();
        private Dictionary<Type, List<IStimuliSource>> _stimuliSources = new();

        // TODO: Break the stimuli source registration into a separate class like StimuliSourceManager. Same for perception.
        public void RegisterStimuli<T>(IStimuliSource stimuliSource) where T : IAISense
        {
            RegisterStimuli(typeof(T), stimuliSource);
        }

        public void RegisterStimuli(Type type, IStimuliSource stimuliSource)
        {
            if (!_stimuliSources.ContainsKey(type))
                _stimuliSources[type] = new List<IStimuliSource>();
            
            if (!_stimuliSources[type].Contains(stimuliSource))
                _stimuliSources[type].Add(stimuliSource);
        }

        public void UnregisterStimuli<T>(IStimuliSource stimuliSource) where T : IAISense
        {
            UnregisterStimuli(typeof(T), stimuliSource);
        }

        public void UnregisterStimuli(Type type, IStimuliSource stimuliSource)
        {
            if (!_stimuliSources.ContainsKey(type))
                return;

            _stimuliSources[type].Remove(stimuliSource);

            if (_stimuliSources[type].Count == 0)
            {
                _stimuliSources.Remove(type);
            }
        }

        public void RegisterSense<T>(IAIPerception perception) where T : IAISense
        {
            RegisterSense(typeof(T), perception);
        }

        public void RegisterSense(Type type, IAIPerception perception)
        {
            if (!_perceptionSenses.ContainsKey(type))
                _perceptionSenses[type] = new List<IAIPerception>();
            
            if (!_perceptionSenses[type].Contains(perception))
                _perceptionSenses[type].Add(perception);
        }

        public void UnregisterSense<T>(IAIPerception perception) where T : IAISense
        {
            UnregisterSense(typeof(T), perception);
        }

        public void UnregisterSense(Type type, IAIPerception perception)
        {
            if (!_perceptionSenses.ContainsKey(type))
                return;

            _perceptionSenses[type].Remove(perception);

            if (_perceptionSenses[type].Count == 0)
            {
                _perceptionSenses.Remove(type);
            }
        }

        public void Alert<T>(IPerceptionData perceptionData) where T : IAISense
        {
            Alert(typeof(T), perceptionData);
        }

        public void Alert(Type type, IPerceptionData perceptionData)
        {
            if (!_perceptionSenses.TryGetValue(type, out var sense))
                return;

            foreach (var perception in sense)
            {
                perception.NotifyPerceptionEvent(type, perceptionData);
            }
        }
    }
}