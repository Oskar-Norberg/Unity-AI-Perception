using System;
using ringo.AIPerception.Senses;
using UnityEngine;

namespace ringo.AIStimuliSource.Implementation
{
    public abstract class MonoStimuliSource<TSense, TSenseData> : MonoBehaviour, IStimuliSource,
        IStimuliSource<TSense, TSenseData> where TSense : IAISense where TSenseData : IPerceptionData
    {
        public Type SenseType => typeof(TSense);
        public Type DataType => typeof(TSenseData);
        
        [SerializeField] private bool activateOnStart = true;
        
        public abstract TSenseData GetSenseDataTypedInternal();
        
        public abstract void ActivateStimuliSourceInternal();
        public abstract void DeactivateStimuliSourceInternal();

        protected void Start()
        {
            if (activateOnStart)
            {
                ActivateStimuliSourceInternal();
            }
        }

        public T GetSenseDataTyped<T>() where T : IPerceptionData
        {
            // TODO: Ugly cast.
            return (T)(IPerceptionData) GetSenseDataTypedInternal();
        }

        public TSenseData GetSenseDataTyped()
        {
            return GetSenseDataTypedInternal();
        }

        void IStimuliSource<TSense, TSenseData>.ActivateStimuliSource()
        {
            ActivateStimuliSourceInternal();
        }

        void IStimuliSource<TSense, TSenseData>.DeactivateStimuliSource()
        {
            DeactivateStimuliSourceInternal();
        }

        void IStimuliSource.ActivateStimuliSource()
        {
            ActivateStimuliSourceInternal();
        }

        void IStimuliSource.DeactivateStimuliSource()
        {
            DeactivateStimuliSourceInternal();
        }
    }
}