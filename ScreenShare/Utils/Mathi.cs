using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenShare.Utils
{
    internal static class Mathi
    {
        public static int Clamp(int value, int min, int max) => (value < min) ? min : (value > max) ? max : value;
    }
}
