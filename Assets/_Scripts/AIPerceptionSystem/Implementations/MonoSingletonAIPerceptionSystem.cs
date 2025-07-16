using ringo.AIPerception;
using ringo.AIPerception.Senses;
using UnityEngine;

namespace ringo.AIPerceptionSystem
{
    public class MonoSingletonAIPerceptionSystem : MonoBehaviour, IAIPerceptionSystem
    {
        public static MonoSingletonAIPerceptionSystem Instance { get; private set; }
        
        private AIPerceptionSystem _perceptionSystem;

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
                _perceptionSystem = new AIPerceptionSystem();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void RegisterSense(IPerceptionSense sense, IAIPerception perception)
        {
            _perceptionSystem.RegisterSense(sense, perception);
        }

        public void UnregisterSense(IPerceptionSense sense, IAIPerception perception)
        {
            _perceptionSystem.UnregisterSense(sense, perception);
        }

        public void Alert<T>(IPerceptionData perceptionData) where T : IPerceptionSense
        {
            _perceptionSystem.Alert<T>(perceptionData);
        }
    }
}