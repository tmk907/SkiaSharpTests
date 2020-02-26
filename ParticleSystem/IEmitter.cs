namespace ParticleSystem
{
    public interface IEmitter
    {
        Particle2D[] Particles { get; }

        int MaxParticleCount { get; }
        int AliveParticleCount { get; }

        void Update();
    }
}
