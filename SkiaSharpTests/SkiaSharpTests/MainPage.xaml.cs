using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Diagnostics;

namespace SkiaSharpTests
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private bool _isPageActive = false;
        private Stopwatch stopwatch = new Stopwatch();
        private double _fps = 0;

        private SKPaint _textStyle = new SKPaint() { Color = new SKColor(0, 0, 0), TextSize = 20 };

        public MainPage()
        {
            InitializeComponent();
            GenerateParticles();
            canvas.PaintSurface += Canvas_PaintSurface;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _isPageActive = true;
            //AnimationLoop();
            Device.StartTimer(TimeSpan.FromSeconds(1.0 / 30.0), () =>
            {
                canvas.InvalidateSurface();
                return _isPageActive;
            });
        }

        protected override void OnDisappearing()
        {
            _isPageActive = false;
            base.OnDisappearing();
        }

        private void Canvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear();

            DrawParticles(canvas);
            DrawFps(canvas);
            UpdateParticles();
        }

        private async Task AnimationLoop()
        {

            while (_isPageActive)
            {
                stopwatch.Restart();

                canvas.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 40.0));

                stopwatch.Stop();
                _fps = 1000.0 / stopwatch.ElapsedMilliseconds;
            }
        }

        private void DrawFps(SKCanvas canvas)
        {
            canvas.DrawText($"FPS: {_fps.ToString("N2")}", 50, 50, _textStyle);
        }

        private void DrawParticles(SKCanvas canvas)
        {
            for (int i = 0; i < MaxParticles; i++)
            {
                canvas.DrawCircle(_particles[i].Point, 10, _particles[i].Paint);
            }
        }

        public void UpdateParticles()
        {
            for(int i = 0; i < MaxParticles; i++)
            {
                var particle = _particles[i];
                particle.Point += particle.Velocity;
                particle.Life -= 1;
            }
        }

        private Random rnd = new Random();
        private const int MaxParticles = 100;
        private Particle[] _particles;

        private void GenerateParticles()
        {
            _particles = new Particle[MaxParticles];
            for (int i = 0; i < MaxParticles; i++)
            {
                var color = new SKColor((byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256));
                var point = new SKPoint(rnd.Next(0, 800), rnd.Next(0, 600));
                var velocity = new SKPoint(rnd.Next(-5, 5), rnd.Next(-5, 5));
                _particles[i] = new Particle(color)
                {
                    Point = point,
                    Velocity = velocity,
                    Life = 200,
                };
            }
        }
    }

    public class Particle
    {
        public SKPoint Point;
        public SKPaint Paint;

        public SKPoint Velocity;
        public SKPoint Forces;

        public int Life;

        public Particle(SKColor color)
        {
            Point = new SKPoint();
            Velocity = new SKPoint();
            Forces = new SKPoint();
            Paint = new SKPaint() { Color = color };
        }
    }
}
