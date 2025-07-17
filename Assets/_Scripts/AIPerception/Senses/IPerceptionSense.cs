using System;
using UnityEngine;

namespace ringo.AIPerception.Senses
{
    
    public interface IPerceptionSense<TPerceptionData> where TPerceptionData : ISenseData
    {
        // TODO: I don't love sending a raw transform here. Inherently linked to Unity, so harder for Unit tests.
        bool ConditionMet(Transform perceiver, ISenseData senseData);
    }
    
    // Marker interface for non-generic sense types.
    public interface IPerceptionSense
    {
        public Type PerceptionType { get; }
        
        bool ConditionMet(Transform perceiver, ISenseData senseData);
    }
}