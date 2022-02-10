using NSA.Searching;
using Xunit;

namespace SearchTests
{
    public class RabinKarpTests
    {
        [Fact]
        public void Should_find_one_substring_at_start()
        {
            // Arrange
            var input = "abac";
            var pattern = "ab";
            
            // Act
            var count = Search.RabinKarp(input, pattern);

            // Assert
            Assert.Equal(1, count);
        }

        [Fact]
        public void Should_find_one_substring_at_end()
        {
            // Arrange
            var input = "abac";
            var pattern = "ac";

            // Act
            var count = Search.RabinKarp(input, pattern);

            // Assert
            Assert.Equal(1, count);
        }
        
        [Fact]
        public void Should_find_two_substrings()
        {
            // Arrange
            var input = "abavacacac";
            var pattern = "ac";

            // Act
            var count = Search.RabinKarp(input, pattern);

            // Assert
            Assert.Equal(3, count);
        }
        
        [Fact]
        public void Should_find_five_substrings_with_one_symbol()
        {
            // Arrange
            var input = "abavacacac";
            var pattern = "a";

            // Act
            var count = Search.RabinKarp(input, pattern);

            // Assert
            Assert.Equal(5, count);
        }
    }
}