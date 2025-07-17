using System;
using System.Collections.Generic;
using ringo.AIPerception;
using ringo.AIPerception.Senses;
using ringo.AIStimuliSource;
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

        public IEnumerable<IStimuliSource> GetStimuliSources()
        {
            return _perceptionSystem.GetStimuliSources();
        }

        public IEnumerable<IStimuliSource> GetStimuliSourcesOfType<T>() where T : ISenseData
        {
            return _perceptionSystem.GetStimuliSourcesOfType<T>();
        }

        public IEnumerable<IStimuliSource> GetStimuliSourcesOfType(Type type)
        {
            return _perceptionSystem.GetStimuliSourcesOfType(type);
        }

        public void RegisterStimuli<T>(IStimuliSource stimuliSource) where T : ISenseData
        {
            _perceptionSystem.RegisterStimuli<T>(stimuliSource);
        }

        public void RegisterStimuli(Type type, IStimuliSource stimuliSource)
        {
            _perceptionSystem.RegisterStimuli(type, stimuliSource);
        }

        public void UnregisterStimuli<T>(IStimuliSource stimuliSource) where T : ISenseData
        {
            _perceptionSystem.UnregisterStimuli<T>(stimuliSource);
        }

        public void UnregisterStimuli(Type type, IStimuliSource stimuliSource)
        {
            _perceptionSystem.UnregisterStimuli(type, stimuliSource);
        }

        public void RegisterSense<T>(IAIPerception perception) where T : ISenseData
        {
            _perceptionSystem.RegisterSense<T>(perception);
        }

        public void RegisterSense(Type type, IAIPerception perception)
        {
            _perceptionSystem.RegisterSense(type, perception);
        }

        public void UnregisterSense<T>(IAIPerception perception) where T : ISenseData
        {
            _perceptionSystem.UnregisterSense<T>(perception);
        }

        public void UnregisterSense(Type type, IAIPerception perception)
        {
            _perceptionSystem.UnregisterSense(type, perception);
        }

        public void Alert<T>(ISenseData senseData) where T : ISenseData
        {
            _perceptionSystem.Alert<T>(senseData);
        }

        public void Alert(Type type, ISenseData senseData)
        {
            _perceptionSystem.Alert(type, senseData);
        }
    }
}