using UnityEngine;

namespace ringo.AIPerception.Senses
{
    public abstract class AISenseSO : ScriptableObject, IPerceptionSense
    {
        public abstract bool ConditionMet(Transform perceiver, IPerceptionData perceptionData);
    }
}