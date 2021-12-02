using System;
using System.Collections;

namespace SQRA.Infrastructure.Extensions
{
    public static class IntToBitConvertExtension
    {
        public static bool[] GetBits(this int value)
        {
            var binary = Convert.ToString(value, 2);
            var result = new bool[binary.Length];

            for (var i = 0; i < binary.Length; i++)
            {
                result[i] = binary[i] == '1';
            }

            return result;
        }
    }
}