using ringo.AIPerception.Senses;

namespace ringo.AIPerception
{
    public interface IAIPerception
    {
        void SetActive(bool isActive);
        
        void NotifyPerceptionEvent<T>(IPerceptionData perceptionData) where T : IAISense;
        void NotifyPerceptionEvent(System.Type type, IPerceptionData perceptionData);
    }
}