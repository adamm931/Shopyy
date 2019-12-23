using System;

namespace Shopyy.Common.Guard
{
    /// <summary>
    /// Logic for ensuring that given paramters satifies certain rules
    /// </summary>
    public class Ensure
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if given argument is null or empty
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="arugmentName"></param>
        public static void NotEmpty(string argument, string arugmentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullException(arugmentName);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNegativeException"/> if given argument is negative number
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="arugmentName"></param>
        public static void NonNegative(decimal argument, string arugmentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNegativeException(arugmentName);
            }
        }
    }
}
