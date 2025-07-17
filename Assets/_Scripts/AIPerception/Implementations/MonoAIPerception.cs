using System;
using System.Collections.Generic;
using ringo.AIPerception.Senses;
using ringo.AIPerceptionSystem;
using UnityEngine;

namespace ringo.AIPerception.Implementations
{
    public class MonoAIPerception : MonoBehaviour, IAIPerception
    {
        public delegate void OnPerceivedEventHandler(Type perceptionType, ISenseData senseData);
        public event OnPerceivedEventHandler OnPerceived;

        [SerializeField] private bool enableOnStart = true;
        [SerializeField] private List<AISenseSOBase> senses = new();

        private void Start()
        {
            if (enableOnStart)
            {
                SetActive(true);
            }
        }

        public void SetActive(bool isActive)
        {
            if (isActive)
            {
                foreach (var sense in senses)
                {
                    MonoSingletonAIPerceptionSystem.Instance.RegisterSense(sense.PerceptionType, this);
                }
            }
            else
            {
                foreach (var sense in senses)
                {
                    MonoSingletonAIPerceptionSystem.Instance.UnregisterSense(sense.PerceptionType, this);
                }
            }
        }

        public void NotifyPerceptionEvent<T>(T senseData) where T : ISenseData
        {
            NotifyPerceptionEvent(typeof(T), senseData);
        }

        public void NotifyPerceptionEvent(Type type, ISenseData senseData)
        {
            // Needs to find the sense in the list of senses and see if its condition is met.
            // Stupid O(n) loop. Make into dict of type -> sense ref.
            foreach (var sense in senses)
            {
                if (sense.PerceptionType == type)
                {
                    if (!sense.ConditionMet(transform, senseData))
                    {
                        return;
                    }

                    OnPerceived?.Invoke(type, senseData);
                    return;
                }
            }
        }
    }
}