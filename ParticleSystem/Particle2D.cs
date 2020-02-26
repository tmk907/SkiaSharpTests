using System.Numerics;

namespace ParticleSystem
{
    public class Particle2D
    {
        public Vector2 Position;
        public Vector4 Color;
        public Vector4 DeltaColor;

        public Vector2 Velocity;
        public Vector2 Forces;
        public float Mass;

        public float Life;

        public bool IsDead => Life <= 0;

        public Particle2D()
        {
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            Forces = Vector2.Zero;
            DeltaColor = Vector4.Zero;
            Color = Vector4.Zero;
            Mass = 1f;
            Life = 0f;
        }

        public void AddForce(Vector2 force)
        {
            Forces += force;
        }

        public void ClearForces()
        {
            Forces = Vector2.Zero;
        }
    }
}
