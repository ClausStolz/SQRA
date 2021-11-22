using System;
using System.Collections;

namespace SQRA.Infrastructure.Extensions
{
    public static class LimitValidationExtension
    {
        public static void LimitValidation(this IList value, int valueLimit)
        {
            if (value.Count > valueLimit)
            {
                throw new ArgumentOutOfRangeException(
                    $"Value {value} longer than maximum limit size."
                );
            }
        }
        
        public static void LimitValidation(this string value, int valueLimit)
        {
            if (value.Length > valueLimit)
            {
                throw new ArgumentOutOfRangeException(
                    $"Value {value} longer than maximum limit size."
                );
            }
        }
    }
}