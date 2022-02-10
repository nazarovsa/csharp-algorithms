using System;
using System.Text.RegularExpressions;

namespace NSA.Searching
{
    public static partial class Search
    {
        private static Regex _validationRegex = new Regex("^[a-z]{1,}$");
        
        /// <summary>
        /// Rabin-Karp searching algorithm implementation.
        /// </summary>
        /// <param name="input">Input string. Should contain only a-z characters.</param>
        /// <param name="pattern">Pattern of searching substring. Should contain only a-z characters.</param>
        /// <param name="baseOfNumeralSystem">Base of a numeral system..</param>
        /// <param name="primeNumber">Prime number used to calculate modulo.</param>
        /// <returns>Number of occurrences of pattern substring in input. If nothing found - returns -1.</returns>
        public static int RabinKarp(string input, string pattern, int baseOfNumeralSystem = 256, int primeNumber = 101)
        {
            if (pattern.Length > input.Length)
                throw new InvalidOperationException("Pattern length is bigger than input length.");

            if (!IsInputValid(pattern))
                throw new InvalidOperationException("Pattern should contain only a-z characters and contain at least one character.");

            if (!IsInputValid(input))
                throw new InvalidOperationException("Input should contain only a-z characters  and contain at least one character.");

            var count = 0;
            var patternHash = 0;
            var segmentHash = 0;

            var symbolDiff = Modulo((int)Math.Pow(baseOfNumeralSystem, pattern.Length - 1), primeNumber);

            for (var i = 0; i < pattern.Length; i++)
            {
                patternHash = Modulo(patternHash * baseOfNumeralSystem + pattern[i], primeNumber);
                segmentHash = Modulo(segmentHash * baseOfNumeralSystem + input[i], primeNumber);
            }

            for (var i = 0; i <= input.Length - pattern.Length; i++)
            {
                if (patternHash == segmentHash)
                {
                    for (var j = 0; j < pattern.Length; j++)
                    {
                        if (pattern[j] != input[i + j])
                        {
                            break;
                        }

                        if (j == pattern.Length - 1)
                            count++;
                    }
                }

                if (i < input.Length - pattern.Length)
                {
                    segmentHash = Modulo(
                        (segmentHash - input[i] * symbolDiff) * baseOfNumeralSystem + input[i + pattern.Length],
                        primeNumber);
                }
            }

            return count == 0 ? -1 : count;
        }

        private static bool IsInputValid(string input)
        {
            return _validationRegex.IsMatch(input);
        }

        /// <summary>
        /// Right way to calculate modulo.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int Modulo(int a, int b)
        {
            return (a % b + b) % b;
        }
    }
}