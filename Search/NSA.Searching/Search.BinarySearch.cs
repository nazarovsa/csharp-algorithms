using System.Collections.Generic;

namespace NSA.Searching
{
    public static partial class Search
    {
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
