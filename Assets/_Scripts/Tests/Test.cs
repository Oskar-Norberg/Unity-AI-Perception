using ringo.AIStimuliSource.Hearing;
using UnityEngine;

namespace _Scripts.Tests
{
    public class Test : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<MonoHearingStimuliSource>().MakeNoise();
            }
        }
    }
}