using System.Numerics;
using SkiaSharp;

namespace SkiaSharpTests
{
    public static class SKPointExtensions
    {
        public static SKPoint Mult(this SKPoint point, float value)
        {
            var newPoint = new SKPoint();
            newPoint.X = point.X * value;
            newPoint.Y = point.Y * value;
            return newPoint;
        }

        public static SKPoint Divide(this SKPoint point, float value)
        {
            var newPoint = new SKPoint();
            newPoint.X = point.X / value;
            newPoint.Y = point.Y / value;
            return newPoint;
        }
    }

    public static class Utils
    {
        public static SKColor NewSKColor(Vector4 vector)
        {
            var r = Constrain(vector.X * 255, 0, 255);
            var g = Constrain(vector.Y * 255, 0, 255);
            var b = Constrain(vector.Z * 255, 0, 255);
            var a = Constrain(vector.W * 255, 0, 255);

            return new SKColor((byte)r, (byte)g, (byte)b, (byte)a);
        }

        public static float Constrain(float a, float min, float max)
        {
            if (a < min) return min;
            if (a > max) return max;
            return a;
        }
    }

    public static class Vector4Extensions
    {
        public static SKColor ToColor(this Vector4 vector)
        {
            return Utils.NewSKColor(vector);
        }
    }
}
