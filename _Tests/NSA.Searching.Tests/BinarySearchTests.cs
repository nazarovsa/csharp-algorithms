using System;
using NSA.Searching;
using Xunit;

namespace SearchTests
{
    public class BinarySearchTests
    {
        [Fact]
        public void Should_return_minus_one_if_not_found()
        {
            // Arrange
            var array = new[] {1, 2, 3, 4, 5};

            // Act
            var index = Search.BinarySearch(array, 10);

            // Assert
            Assert.Equal(-1, index);
        }

        [Fact]
        public void Should_return_index_of_founded_element()
        {
            // Arrange
            var array = new[] {1, 2, 3, 4, 5};

            // Act
            var index = Search.BinarySearch(array, 3);

            // Assert
            Assert.Equal(Array.IndexOf(array, 3), index);
        }
    }
}