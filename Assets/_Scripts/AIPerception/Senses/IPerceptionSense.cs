using System;
using UnityEngine;

namespace ringo.AIPerception.Senses
{
    
    public interface IPerceptionSense<TSense, TSenseData> where TSense : IAISense where TSenseData : IPerceptionData
    {
        // TODO: I don't love sending a raw transform here. Inherently linked to Unity, so harder for Unit tests.
        bool ConditionMet(Transform perceiver, IPerceptionData perceptionData);
    }
    
    // Marker interface for non-generic sense types.
    public interface IPerceptionSense
    {
        public Type SenseType { get; }
        public Type DataType { get; }
        
        bool ConditionMet(Transform perceiver, IPerceptionData perceptionData);
    }
}