using System;
using ringo.AIPerception.Implementations;
using ringo.AIPerception.Senses;
using UnityEngine;

namespace _Scripts.Tests
{
    public class PerceiverTest : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<MonoAIPerception>().OnPerceived += HandlePerceived;
        }
        
        private void OnDisable()
        {
            GetComponent<MonoAIPerception>().OnPerceived -= HandlePerceived;
        }
        
        private void HandlePerceived(Type perceptionType, ISenseData senseData)
        {
            Debug.Log("Perceived: " + perceptionType.Name + " with data: " + senseData);
        }
    }
}