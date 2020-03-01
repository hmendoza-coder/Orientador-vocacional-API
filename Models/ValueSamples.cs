using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI
{
    public static class ValueSamples
    {
        public static Dictionary<int, string> MyValue;

        public static void Initialize()
        {
            MyValue = new Dictionary<int, string> {{0, "Value 0"}, {1, "Value 1"}, {2, "Value 2"}};
        }
    }
}
