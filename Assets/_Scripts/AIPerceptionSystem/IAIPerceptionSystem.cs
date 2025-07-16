using System;
using System.Collections.Generic;
using ringo.AIPerception;
using ringo.AIPerception.Senses;
using ringo.AIStimuliSource;

namespace ringo.AIPerceptionSystem
{
    public interface IAIPerceptionSystem
    {
        public IEnumerable<IStimuliSource> GetStimuliSources();
        public IEnumerable<IStimuliSource> GetStimuliSourcesOfType<T>() where T : IAISense;
        public IEnumerable<IStimuliSource> GetStimuliSourcesOfType(Type type);
        
        public void RegisterStimuli<T>(IStimuliSource stimuliSource) where T : IAISense;
        public void RegisterStimuli(Type type, IStimuliSource stimuliSource);
        
        public void UnregisterStimuli<T>(IStimuliSource stimuliSource) where T : IAISense;
        public void UnregisterStimuli(Type type, IStimuliSource stimuliSource);
        
        public void RegisterSense<T>(IAIPerception perception) where T : IAISense;
        // TODO: Rename to senseType, type is too generic
        public void RegisterSense(Type type, IAIPerception perception);

        public void UnregisterSense<T>(IAIPerception perception) where T : IAISense;
        public void UnregisterSense(Type type, IAIPerception perception);


        public void Alert<T>(IPerceptionData perceptionData) where T : IAISense;
        public void Alert(Type type, IPerceptionData perceptionData);
    }
}