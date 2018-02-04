using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillar
{
    public static class UniqueRandom
    {
        private static Random rand = new Random(DateTime.Now.Millisecond);

        public static int Rand(float min, float max)
        {
            return rand.Next((int)min, (int)max);
        }

        public static float NextFloat(float min, float max)
        {
            return rand.Next((int)Math.Ceiling(min), (int)max) - (1 - (min % 1)) + ((float)rand.NextDouble() * (min % 1));
        }

        public static float Rand()
        {
            return (float)rand.NextDouble();
        }

        public static void SetRandomSeed(int seed)
        {
            rand = new Random(seed);
        }
    }
}
