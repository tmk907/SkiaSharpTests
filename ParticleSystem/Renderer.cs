using System;
using System.Collections.Generic;
using System.Linq;
using SkiaSharp;

namespace ParticleSystem
{
    public class Renderer
    {
        private readonly List<IEmitter> _emitters;
        private readonly float _pointSize;

        public Renderer(IEmitter emitter, float pointSize)
        {
            _emitters = new List<IEmitter>() { emitter };
            _pointSize = pointSize;
        }

        public Renderer(List<IEmitter> emitters, float pointSize)
        {
            _emitters = new List<IEmitter>(emitters);
            _pointSize = pointSize;
        }

        public void OnRenderFrame(SKCanvas canvas)
        {
            foreach (var emitter in _emitters)
            {
                emitter.Update();
                foreach (var particle in emitter.Particles.Where(p => !p.IsDead))
                {
                    canvas.DrawCircle(particle.GetPoint(), _pointSize, particle.GetPaint());
                }
            }
        }

        public void AddEmitter(IEmitter emitter)
        {
            _emitters.Add(emitter);
        }
    }
}
