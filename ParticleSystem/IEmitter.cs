namespace ParticleSystem
{
    public interface IEmitter<T> where T: Particle2D
    {
        T[] Particles { get; }

        int MaxParticleCount { get; }
        int AliveParticleCount { get; }

        void Update();
    }
}
