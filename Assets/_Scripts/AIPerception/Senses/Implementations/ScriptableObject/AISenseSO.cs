using System;
using UnityEngine;

namespace ringo.AIPerception.Senses
{
    // TODO: These need to be renamed to avoid mixing them up.
    public abstract class AISenseSO<T> : AISenseSOBase, IPerceptionSense<T> where T : IAISense
    {
        public override Type SenseType => typeof(T);

        public abstract override bool ConditionMet(Transform perceiver, IPerceptionData perceptionData);
    }
    
    public abstract class AISenseSOBase : ScriptableObject, IPerceptionSense
    {
        public abstract Type SenseType { get; }
        
        public abstract bool ConditionMet(Transform perceiver, IPerceptionData perceptionData);
    }
}