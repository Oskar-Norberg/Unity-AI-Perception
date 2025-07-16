namespace ringo.AIPerception.Senses
{
    public interface ITickableSense
    {
        void Tick(float deltaTime);
    }
    
    public abstract class AITickableSenseSO<T1, T2> :  AISenseSOBase, ITickableSense, IPerceptionSense<T1, T2> where T1 : IAISense where T2 : IPerceptionData
    {
        public abstract void Tick(float deltaTime);
    }

    public abstract class AITickableSenseSOBase : AISenseSOBase, ITickableSense
    {
        public abstract void Tick(float deltaTime);
    }
}