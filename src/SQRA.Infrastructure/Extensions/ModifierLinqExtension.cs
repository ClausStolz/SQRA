using System;
using System.Collections.Generic;
using System.Linq;


namespace SQRA.Infrastructure.Extensions
{
    public static class ModifierLinqExtension
    {
        /// <summary>
        /// Extension to search first index in IList objects
        /// for satisfying condition. 
        /// </summary>
        /// <param name="obj">
        /// IList implementation.
        /// </param>
        /// <param name="exc">
        /// Delegate with same type parameter that list type,
        /// that call for all values in List till don't found
        /// the satisfying value for this condition.
        /// </param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int GetFirstIndex<T>(this IList<T> obj, Func<T, bool> exc)
        {
            for (var i = 0; i < obj.Count; i++)
            {
                if (exc(obj[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}