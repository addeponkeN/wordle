using System;

namespace Util
{
    public static class Rng
    {
        private static Random _rnd = new();


        public static int Next(int maxIncluded) => _rnd.Next(maxIncluded + 1);
    }
}