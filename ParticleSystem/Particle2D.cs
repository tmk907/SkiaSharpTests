using System.Numerics;
using SkiaSharp;

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

        private SKPoint _point;
        private SKPaint _paint;

        public Particle2D()
        {
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            Forces = Vector2.Zero;
            DeltaColor = Vector4.Zero;
            Color = Vector4.Zero;
            Mass = 1f;
            Life = 0f;

            _point = new SKPoint();
            _paint = new SKPaint();
        }

        public void AddForce(Vector2 force)
        {
            Forces += force;
        }

        public void ClearForces()
        {
            Forces = Vector2.Zero;
        }

        public SKPoint GetPoint()
        {
            _point.X = Position.X;
            _point.Y = Position.Y;
            return _point;
        }

        public SKPaint GetPaint()
        {
            _paint.Color = Color.ToColor();
            return _paint;
        }
    }
}
