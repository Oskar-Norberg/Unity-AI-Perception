using UnityEngine;

namespace ringo.AIPerception.Senses
{
    public interface IPerceptionSense
    {
        // TODO: I don't love sending a raw transform here. Inherently linked to Unity, so harder for Unit tests.
        bool ConditionMet(Transform perceiver, IPerceptionData perceptionData);
    }
}