using System.Numerics;

namespace ParticleSystem.Forces
{
    public class Gravity : IApplyForce
    {
        public Vector2 Force { get; set; } = new Vector2(0, 98f);

        public void ApplyForce(Particle2D particle)
        {
            particle.AddForce(Force);
        }
    }
}
