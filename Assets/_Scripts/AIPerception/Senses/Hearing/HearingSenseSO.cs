using UnityEngine;

namespace ringo.AIPerception.Senses.Hearing
{
    [CreateAssetMenu(fileName = "HearingData", menuName = "AI Senses/Hearing Sense Data")]
    public class HearingSenseSO : AISenseSO<HearingSenseData>
    {
        public float range = 10.0f;

        protected override bool ConditionMetInternal(Transform perceiver, HearingSenseData senseData)
        {
            // Calculate distance from the perceiver to the sound source.
            // TODO: Weird mix of Vector3 and System.Numerics.Vector3.
            float distance = Vector3.Distance(perceiver.position,
                new Vector3(senseData.Position.X, senseData.Position.Y, senseData.Position.Z));

            return distance <= range;
        }
    }
}