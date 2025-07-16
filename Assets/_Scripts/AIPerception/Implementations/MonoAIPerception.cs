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
        [SerializeField] private List<AISenseSO> senses = new();

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
                    MonoSingletonAIPerceptionSystem.Instance.RegisterSense(sense, this);
                }
            }
            else
            {
                foreach (var sense in senses)
                {
                    MonoSingletonAIPerceptionSystem.Instance.UnregisterSense(sense, this);
                }
            }
        }

        public void NotifyPerceptionEvent<T>(IPerceptionData perceptionData) where T : IPerceptionSense
        {
            // Needs to find the sense in the list of senses and see if its condition is met.
            // Stupid O(n) loop. Make into dict of type -> sense ref.
            foreach (var sense in senses)
            {
                if (sense.GetType() == typeof(T))
                {
                    if (!sense.ConditionMet(transform, perceptionData))
                    {
                        return;
                    }

                    OnPerceived?.Invoke(typeof(T), perceptionData);
                    return;
                }
            }
        }
    }
}