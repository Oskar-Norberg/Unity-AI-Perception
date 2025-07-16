using System;
using System.Collections.Generic;
using ringo.AIPerception.Senses;
using ringo.AIPerceptionSystem;
using UnityEngine;

namespace ringo.AIPerception.Implementations
{
    public class MonoAIPerception : MonoBehaviour, IAIPerception
    {
        public delegate void OnPerceivedEventHandler(Type perceptionType, IPerceptionData perceptionData);
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
                    MonoSingletonAIPerceptionSystem.Instance.RegisterSense(sense.SenseType, this);
                }
            }
            else
            {
                foreach (var sense in senses)
                {
                    MonoSingletonAIPerceptionSystem.Instance.UnregisterSense(sense.SenseType, this);
                }
            }
        }

        public void NotifyPerceptionEvent<T>(IPerceptionData perceptionData) where T : IAISense
        {
            NotifyPerceptionEvent(typeof(T), perceptionData);
        }

        public void NotifyPerceptionEvent(Type type, IPerceptionData perceptionData)
        {
            // Needs to find the sense in the list of senses and see if its condition is met.
            // Stupid O(n) loop. Make into dict of type -> sense ref.
            foreach (var sense in senses)
            {
                if (sense.SenseType == type)
                {
                    if (!sense.ConditionMet(transform, perceptionData))
                    {
                        return;
                    }

                    OnPerceived?.Invoke(type, perceptionData);
                    return;
                }
            }
        }
    }
}