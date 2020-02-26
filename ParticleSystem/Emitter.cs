using System;
using System.Collections.Generic;
using System.Numerics;

namespace ParticleSystem
{
    public class Emitter<T> : IEmitter<T> where T : Particle2D, new()
    {
        private Random rnd;

        private int totalParticles;
        private int indexOfLastAlive;
        private T[] particles;

        public T[] Particles { get { return particles; } }

        public int MaxParticleCount { get { return totalParticles; } }
        public int AliveParticleCount { get { return indexOfLastAlive + 1; } }

        private int avgLife;

        public int AvgLife
        {
            get { return avgLife; }
            set
            {
                avgLife = value;
                particleInitializer.SetAverageParticleLife(avgLife);
            }
        }

        private int emissionRate { get { return totalParticles / AvgLife; } }
        private double emitCounter;

        private IParticleInitializer particleInitializer;
        public List<IApplyForce> Forces;

        private float delta = 1 / 60f;

        public Emitter(IParticleInitializer particleInitializer, int totalParticles)
        {
            this.totalParticles = totalParticles;
            indexOfLastAlive = -1;
            rnd = new Random();
            emitCounter = 0;
            avgLife = 3;

            particles = new T[totalParticles];
            for (int i = 0; i < totalParticles; i++)
            {
                particles[i] = new T();
            }
            this.particleInitializer = particleInitializer;
            particleInitializer.SetAverageParticleLife(avgLife);
            Forces = new List<IApplyForce>();
        }

        public void Update()
        {
            if (emissionRate > 0)
            {
                var rate = 1.0 / emissionRate;
                emitCounter += delta;
                while (!IsFull && emitCounter > rate)
                {
                    Add();
                    emitCounter -= rate;
                }
            }

            for (int i = 0; i < particles.Length; i++)
            {
                if (particles[i].IsDead)
                {
                    break;
                }
                foreach (var force in Forces)
                {
                    force.ApplyForce(particles[i]);
                }
                Update(particles[i], delta);
                if (particles[i].IsDead)
                {
                    particles.Swap(i, indexOfLastAlive);
                    indexOfLastAlive--;
                }
            }
        }

        private void Update(T particle, float dt)
        {
            particle.Position += particle.Velocity * dt;
            particle.Velocity += Vector2.Divide(particle.Forces, particle.Mass) * dt;
            particle.ClearForces();
            particle.Color += particle.DeltaColor * dt;
            particle.Life -= dt;
        }

        private void Add()
        {
            if (IsFull)
            {
                return;
            }
            particleInitializer.Init(particles[indexOfLastAlive + 1]);
            indexOfLastAlive++;
        }

        private bool IsFull
        {
            get { return indexOfLastAlive + 1 == totalParticles; }
        }
    }
}
