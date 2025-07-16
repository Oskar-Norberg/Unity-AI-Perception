using System;
using ringo.AIPerception.Senses;

namespace ringo.AIStimuliSource
{ 
    public interface IStimuliSource
    {
        object GetSenseDataTyped<T>() where T : IAISense;
        
        protected void RegisterStimuli<T>() where T : IAISense;
        protected void RegisterStimuli(Type type);
        
        protected void UnregisterStimuli<T>(IStimuliSource stimuliSource) where T : IAISense;
        protected void UnregisterStimuli(Type type, IStimuliSource stimuliSource);
    }
    
    public interface IStimuliSource<T> : IStimuliSource where T : IAISense 
    {
        T GetSenseData();
    }
}