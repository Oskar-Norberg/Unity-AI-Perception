using System;
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

        public void RegisterSense<T>(IAIPerception perception) where T : IAISense
        {
            _perceptionSystem.RegisterSense<T>(perception);
        }

        public void RegisterSense(Type type, IAIPerception perception)
        {
            _perceptionSystem.RegisterSense(type, perception);
        }

        public void UnregisterSense<T>(IAIPerception perception) where T : IAISense
        {
            _perceptionSystem.UnregisterSense<T>(perception);
        }

        public void UnregisterSense(Type type, IAIPerception perception)
        {
            _perceptionSystem.UnregisterSense(type, perception);
        }

        public void Alert<T>(IPerceptionData perceptionData) where T : IAISense
        {
            _perceptionSystem.Alert<T>(perceptionData);
        }

        public void Alert(Type type, IPerceptionData perceptionData)
        {
            _perceptionSystem.Alert(type, perceptionData);
        }

        public void AlertScene(Type type, IPerceptionData perceptionData)
        {
            _perceptionSystem.Alert(type, perceptionData);
        }
    }
}