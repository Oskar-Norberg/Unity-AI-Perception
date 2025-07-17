using System;
using ringo.AIPerception.Senses;

namespace ringo.AIStimuliSource
{ 
    public interface IStimuliSource
    {
        object GetSenseDataTyped<T>() where T : ISenseData;
        
        protected void RegisterStimuli<T>() where T : ISenseData;
        protected void RegisterStimuli(Type type);
        
        protected void UnregisterStimuli<T>(IStimuliSource stimuliSource) where T : ISenseData;
        protected void UnregisterStimuli(Type type, IStimuliSource stimuliSource);
    }
    
    public interface IStimuliSource<out T> : IStimuliSource where T : ISenseData 
    {
        T GetSenseData();
    }
}