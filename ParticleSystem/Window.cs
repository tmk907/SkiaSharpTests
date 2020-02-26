namespace ParticleSystem
{
    public class Window
    {
        public Window(double height, double width)
        {
            Height = (int)height;
            Width = (int)width;
        }

        public int Height { get; set; }
        public int Width { get; set; }
    }
}
