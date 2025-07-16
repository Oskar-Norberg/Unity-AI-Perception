using UnityEngine;

namespace ringo.AIPerception.Senses.Hearing
{
    [CreateAssetMenu(fileName = "HearingData", menuName = "AI Senses/Hearing Sense Data")]
    public class HearingSenseSO : AISenseSO<HearingSense, HearingPerceptionData>
    {
        public float range = 10.0f;

        protected override bool ConditionMet(Transform perceiver, HearingPerceptionData perceptionData)
        {
            // Calculate distance from the perceiver to the sound source.
            // TODO: Weird mix of Vector3 and System.Numerics.Vector3.
            float distance = Vector3.Distance(perceiver.position,
                new Vector3(perceptionData.Position.X, perceptionData.Position.Y, perceptionData.Position.Z));

            return distance <= range;
        }
    }
}