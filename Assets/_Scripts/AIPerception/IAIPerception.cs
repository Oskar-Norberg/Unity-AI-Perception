using ringo.AIPerception.Senses;

namespace ringo.AIPerception
{
    public interface IAIPerception
    {
        void SetActive(bool isActive);
        
        void NotifyPerceptionEvent<T>(T senseData) where T : ISenseData;
        void NotifyPerceptionEvent(System.Type type, ISenseData senseData);
    }
}