using System;
using System.Numerics;
using SkiaSharp;

namespace ParticleSystem
{
    public static class ArrayExtensions
    {
        public static bool Swap<T>(this T[] array, int x, int y)
        {
            if (array.Length <= y || array.Length <= x) return false;

            T buffer = array[x];
            array[x] = array[y];
            array[y] = buffer;

            return true;
        }
    }

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

    public static class RandomExtenions
    {
        public static int Random11(this Random rnd)
        {
            return rnd.Next(int.MaxValue) % 2;
        }
    }

    public static class ColorExtensions
    {
        public static Vector4 ToVector4(this Color color)
        {
            return new Vector4(color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
        }
    }
}
