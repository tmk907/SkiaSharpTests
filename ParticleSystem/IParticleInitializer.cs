namespace ParticleSystem
{
    public interface IParticleInitializer
    {
        void Init(Particle2D particle);

        void SetStartColor(Color color);
        void SetEndColor(Color color);
        void SetAverageParticleLife(int avgLife);
    }
}
