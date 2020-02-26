using System;
using System.Numerics;

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
