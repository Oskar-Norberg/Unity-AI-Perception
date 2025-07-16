using UnityEngine;

namespace ringo.AIPerception.Senses.Hearing
{
    [CreateAssetMenu(fileName = "HearingData", menuName = "AI Senses/Hearing Sense Data")]
    public class HearingSenseSO : AISenseSO
    {
        public float range = 10.0f;

        public override bool ConditionMet(Transform perceiver, IPerceptionData perceptionData)
        {
            if (perceptionData is not HearingPerceptionData hearingData || !perceiver)
            {
                return false;
            }

            // Calculate distance from the perceiver to the sound source.
            // TODO: Weird mix of Vector3 and System.Numerics.Vector3.
            float distance = Vector3.Distance(perceiver.position,
                new Vector3(hearingData.Position.X, hearingData.Position.Y, hearingData.Position.Z));

            return distance <= range;
        }
    }
}