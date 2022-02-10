using System.Collections.Generic;

namespace NSA.Searching
{
    public static partial class Search
    {
        /// <summary>
        /// Recursive binary search implementation.
        /// </summary>
        /// <remarks>https://en.wikipedia.org/wiki/Binary_search_algorithm</remarks>
        /// <param name="source">IList of input elements.</param>
        /// <param name="target">The element to be found.</param>
        /// <param name="comparer">Comparer for elements of type T. Uses default comparer for type T if not passed.</param>
        /// <typeparam name="T">Type of element.</typeparam>
        /// <returns>Index of element or -1 if not found.</returns>
        public static int BinarySearch<T>(IList<T> source, T target, IComparer<T> comparer = null)
            => BinarySearch(source, 0, source.Count - 1, target, comparer);

        private static int BinarySearch<T>(IList<T> source, int left, int right, T target, IComparer<T> comparer = null)
        {
            comparer ??= Comparer<T>.Default;
            if (right >= left)
            {
                var median = left + (right - left) / 2;
                if (comparer.Compare(source[median], target) == 0)
                    return median;

                if (comparer.Compare(source[median], target) < 0)
                    return BinarySearch(source, median + 1, right, target);

                return BinarySearch(source, left, median - 1, target);
            }

            return -1;
        }
    }
}