using System;
using System.Numerics;

namespace ParticleSystem
{
    public abstract class ParticleInitializerBase : IParticleInitializer
    {
        protected readonly Random rnd;
        protected readonly Window _window;

        protected Vector4 baseStartColor;
        protected Vector4 baseEndColor;

        protected int _avgLife;

        public ParticleInitializerBase(Window window)
        {
            rnd = new Random();
            _window = window;
        }

        public abstract void Init(Particle2D particle);

        public void SetStartColor(Color color)
        {
            baseStartColor = color.ToVector4();
        }

        public void SetEndColor(Color color)
        {
            baseEndColor = color.ToVector4();
        }

        public void SetAverageParticleLife(int avgLife)
        {
            _avgLife = avgLife;
        }

        protected Vector2 ScreenCenter()
        {
            return new Vector2(_window.Width / 2, _window.Height / 2);
        }

        protected Vector4 RandomColor()
        {
            int r = 32 * rnd.Next(0, 7);
            int g = 32 * rnd.Next(0, 7);
            int b = 22 * rnd.Next(0, 7);
            return new Vector4(r / 255f, b / 255f, b / 255f, 1);
        }
    }
}
