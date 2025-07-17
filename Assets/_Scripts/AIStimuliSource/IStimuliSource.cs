using System;
using ringo.AIPerception.Senses;

namespace ringo.AIStimuliSource
{ 
    public interface IStimuliSource<TSense, TSenseData> where TSense : IAISense where TSenseData : IPerceptionData
    {
        TSenseData GetSenseDataTyped();

        protected void ActivateStimuliSource();
        protected void DeactivateStimuliSource();
    }
    
    public interface IStimuliSource
    {
        public Type SenseType { get; }
        public Type DataType { get; }
        
        T GetSenseDataTyped<T>() where T : IPerceptionData;
        
        protected void ActivateStimuliSource();
        protected void DeactivateStimuliSource();
    }
}