using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkiaSharpTests
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DemoPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
