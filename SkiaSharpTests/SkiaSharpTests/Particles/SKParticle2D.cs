using ParticleSystem;
using SkiaSharp;

namespace SkiaSharpTests.Particles
{
    public class SKParticle2D : Particle2D
    {
        private SKPoint _point;
        private SKPaint _paint;

        public SKParticle2D() : base()
        {
            _point = new SKPoint();
            _paint = new SKPaint();
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
