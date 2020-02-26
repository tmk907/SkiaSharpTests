using System;
using System.Numerics;

namespace ParticleSystem
{
    public class PointParticleInitializer : ParticleInitializerBase
    {
        private readonly Vector2 _position;
        public Vector2 Direction { get; set; }

        public PointParticleInitializer(Window window, Vector2 position) : base(window)
        {
            SetStartColor(new Color("#FF0000"));
            SetEndColor(new Color("#1100FF00"));

            _position = position;
        }

        protected Vector4 GetDeltaColor(Vector4 startColor, Vector4 endColor, float totalLife)
        {
            return new Vector4(
                (endColor.X - startColor.X) / totalLife,
                (endColor.Y - startColor.Y) / totalLife,
                (endColor.Z - startColor.Z) / totalLife,
                (endColor.W - startColor.W) / totalLife
                );
        }

        public override void Init(Particle2D particle)
        {
            var startColor = baseStartColor + new Vector4(0.1f, 0.1f, 0.1f, 0f) * rnd.Random11();
            var endColor = baseEndColor + new Vector4(0.01f, 0.01f, 0.01f, 0f) * rnd.Random11();

            int a = (int)(_avgLife * 0.5);
            particle.Life = rnd.Next(_avgLife - a, _avgLife + a);

            particle.Color = startColor;
            particle.DeltaColor = GetDeltaColor(startColor, endColor, particle.Life);
            particle.Position = _position;
            particle.Velocity = RandomVelocity();
        }

        protected Vector2 RandomVelocity()
        {
            var angle = rnd.NextDouble() * 2 * Math.PI;
            var x = Math.Cos(angle);
            var y = Math.Sin(angle);

            double speed = rnd.Next(200, 1000) / 10.0;

            return Vector2.Multiply(Vector2.Normalize(new Vector2((float)x, (float)y)), (float)speed);
        }
    }
}
