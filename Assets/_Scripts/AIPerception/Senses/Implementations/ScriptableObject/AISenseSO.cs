using System;
using UnityEngine;

namespace ringo.AIPerception.Senses
{
    // TODO: These need to be renamed to avoid mixing them up.
    public abstract class AISenseSO<T, T2> : AISenseSOBase, IPerceptionSense<T, T2> where T : IAISense where T2 : IPerceptionData
    {
        public override Type SenseType => typeof(T);
        public override Type DataType => typeof(T2);

        public override bool ConditionMet(Transform perceiver, IPerceptionData perceptionData)
        {
            if (perceptionData is not T2 data)
            {
                return false;
            }

            return ConditionMet(perceiver, data);
        }
        
        protected abstract bool ConditionMet(Transform perceiver, T2 perceptionData);
    }
    
    public abstract class AISenseSOBase : ScriptableObject, IPerceptionSense
    {
        public abstract Type SenseType { get; }
        public abstract Type DataType { get; }

        public abstract bool ConditionMet(Transform perceiver, IPerceptionData perceptionData);
    }
}