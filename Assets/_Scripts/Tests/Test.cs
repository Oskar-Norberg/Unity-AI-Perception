using ringo.AIPerception.Senses.Hearing;
using ringo.AIPerceptionSystem;
using UnityEngine;

namespace _Scripts.Tests
{
    public class Test : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MonoSingletonAIPerceptionSystem.Instance.Alert<HearingSenseSO>(new HearingPerceptionData
                    { Position = new System.Numerics.Vector3(transform.position.x, transform.position.y, transform.position.z) });
            }
        }
    }
}