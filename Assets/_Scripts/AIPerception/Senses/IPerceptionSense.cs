using System;
using UnityEngine;

namespace ringo.AIPerception.Senses
{
    
    public interface IPerceptionSense<in TPerceptionData> where TPerceptionData : ISenseData
    {
        // TODO: I don't love sending a raw transform here. Inherently linked to Unity, so harder for Unit tests.
        bool ConditionMet(Transform perceiver, TPerceptionData senseData);
    }
    
    // Marker interface for non-generic sense types.
    public interface IPerceptionSense : IPerceptionSense<ISenseData>
    {
        public Type PerceptionType { get; }
    }
}