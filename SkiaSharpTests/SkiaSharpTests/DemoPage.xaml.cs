using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ParticleSystem;
using ParticleSystem.Forces;
using SkiaSharp.Views.Forms;
using SkiaSharpTests.Particles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkiaSharpTests
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemoPage : ContentPage
    {
        private bool _isPageActive = false;
        private Renderer _renderer;
        private IEmitter<SKParticle2D> _emitter;
        private double _density;

        public DemoPage()
        {
            InitializeComponent();
            _density = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _isPageActive = true;

            var ppi = new PointParticleInitializer(new Window(Height, Width), new Vector2(300, 200));
            _emitter = new Emitter<SKParticle2D>(ppi, 100)
            {
                //AvgLife = 5,
                Forces = new List<IApplyForce>()
                {
                    new Gravity()
                }
            };
            _renderer = new Renderer(_emitter, (int)(5 *_density));
            canvas.PaintSurface += Canvas_PaintSurface;

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

            _renderer.OnRenderFrame(canvas);
        }

        private void OnTouch(object sender, TouchTracking.TouchActionEventArgs args)
        {
            if (args.Type == TouchTracking.TouchActionType.Pressed)
            {
                var x = args.Location.X * _density;
                var y = args.Location.Y * _density;

                var ppi = new PointParticleInitializer(new Window(Height, Width), new Vector2((float)x, (float)y));
                var emitter = new Emitter<SKParticle2D>(ppi, 100)
                {
                    //AvgLife = 5,
                    Forces = new List<IApplyForce>()
                    {
                        new Gravity()
                    }
                };
                _renderer.AddEmitter(emitter);
            }
        }
    }
}