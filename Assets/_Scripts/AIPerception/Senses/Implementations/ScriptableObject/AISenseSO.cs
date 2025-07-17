using System;
using UnityEngine;

namespace ringo.AIPerception.Senses
{
    // TODO: These need to be renamed to avoid mixing them up.
    public abstract class AISenseSO<TPerceptionData> : AISenseSOBase, IPerceptionSense<TPerceptionData> where TPerceptionData : ISenseData
    {
        public override Type PerceptionType => typeof(TPerceptionData);

        public override bool ConditionMet(Transform perceiver, ISenseData senseData)
        {
            if (senseData is not TPerceptionData data)
            {
                return false;
            }

            return ConditionMetInternal(perceiver, data);
        }
        
        public bool ConditionMet(Transform perceiver, TPerceptionData senseData)
        {
            return ConditionMetInternal(perceiver, senseData);
        }
        
        protected abstract bool ConditionMetInternal(Transform perceiver, TPerceptionData senseData);
    }
    
    public abstract class AISenseSOBase : ScriptableObject, IPerceptionSense
    {
        public abstract Type PerceptionType { get; }

        public abstract bool ConditionMet(Transform perceiver, ISenseData senseData);
    }
}