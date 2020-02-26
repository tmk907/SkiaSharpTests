using System.Collections.Generic;
using System.Linq;
using ParticleSystem;
using SkiaSharp;

namespace SkiaSharpTests.Particles
{
    public class Renderer
    {
        private readonly List<IEmitter<SKParticle2D>> _emitters;
        private readonly float _pointSize;

        public Renderer(IEmitter<SKParticle2D> emitter, float pointSize)
        {
            _emitters = new List<IEmitter<SKParticle2D>>() { emitter };
            _pointSize = pointSize;
        }

        public Renderer(List<IEmitter<SKParticle2D>> emitters, float pointSize)
        {
            _emitters = new List<IEmitter<SKParticle2D>>(emitters);
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

        public void AddEmitter(IEmitter<SKParticle2D> emitter)
        {
            _emitters.Add(emitter);
        }
    }
}
