using System.Globalization;

namespace ParticleSystem
{
    public struct Color
    {
        public int R;
        public int G;
        public int B;
        public int A;

        public Color(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public Color(string hexString)
        {
            if(hexString.Length == 7)
            {
                R = int.Parse(hexString.Substring(1, 2), NumberStyles.AllowHexSpecifier);
                G = int.Parse(hexString.Substring(3, 2), NumberStyles.AllowHexSpecifier);
                B = int.Parse(hexString.Substring(5, 2), NumberStyles.AllowHexSpecifier);
                A = 255;
            }
            else if(hexString.Length == 9)
            {
                A = int.Parse(hexString.Substring(1, 2), NumberStyles.AllowHexSpecifier);
                R = int.Parse(hexString.Substring(3, 2), NumberStyles.AllowHexSpecifier);
                G = int.Parse(hexString.Substring(5, 2), NumberStyles.AllowHexSpecifier);
                B = int.Parse(hexString.Substring(7, 2), NumberStyles.AllowHexSpecifier);
            }
            else
            {
                R = G = B = A = 0;
            }
        }
    }
}
