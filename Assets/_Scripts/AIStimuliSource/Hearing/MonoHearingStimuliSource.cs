using System.Numerics;
using ringo.AIPerception.Senses.Hearing;
using ringo.AIPerceptionSystem;
using ringo.AIStimuliSource.Implementation;

namespace ringo.AIStimuliSource.Hearing
{
    public class MonoHearingStimuliSource : MonoStimuliSource<HearingSense, HearingPerceptionData>
    {
        public void MakeNoise()
        {
            MonoSingletonAIPerceptionSystem.Instance.Alert<HearingSense>(new HearingPerceptionData
                { Position = new Vector3(transform.position.x, transform.position.y, transform.position.z) });
        }

        public override HearingPerceptionData GetSenseDataTypedInternal()
        {
            return default;
        }

        public override void ActivateStimuliSourceInternal()
        {
            // TODO: Temporarily use the singleton version. But should be agnostic to how its set up.
            // This should also be wrapped in a MonoSingletonStimuliSource class so this only has to be written once.
            MonoSingletonAIPerceptionSystem.Instance.RegisterStimuli<HearingSense>(this);
        }

        public override void DeactivateStimuliSourceInternal()
        {
            MonoSingletonAIPerceptionSystem.Instance.UnregisterStimuli<HearingSense>(this);
        }
    }
}