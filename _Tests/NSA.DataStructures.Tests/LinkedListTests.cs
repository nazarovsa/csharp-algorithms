using System.Linq;
using Xunit;

namespace NSA.DataStructures.Tests
{
    public class LinkedListTests
    {
        [Fact]
        public void Should_AddFirst_and_AddLast_to_list()
        {
            // Arrange
            var list = new LinkedList<int>();
            var first = new LinkedList<int>.ListNode<int> {Value = 1};
            var last = new LinkedList<int>.ListNode<int> {Value = 2};

            // Act
            list.AddFirst(first);
            list.AddLast(last);

            // Assert
            Assert.NotEmpty(list);
            Assert.Equal(2, list.Count);
            Assert.Equal(first.Value, list.First().Value);
            Assert.Equal(last.Value, list.Last().Value);
        }

        [Fact]
        public void Should_Reverse_list()
        {
            // Arrange
            var list = new LinkedList<int>();
            var first = new LinkedList<int>.ListNode<int> {Value = 1};
            var last = new LinkedList<int>.ListNode<int> {Value = 2};

            list.AddFirst(first);
            list.AddLast(last);

            // Act
            list.Reverse();

            // Assert
            Assert.NotEmpty(list);
            Assert.Equal(2, list.Count);
            Assert.Equal(last.Value, list.First().Value);
            Assert.Equal(first.Value, list.Last().Value);
        }

        [Fact]
        public void Should_GetAt2_from_list()
        {
            // Arrange
            var list = new LinkedList<int>();
            var first = new LinkedList<int>.ListNode<int> {Value = 1};
            var middle = new LinkedList<int>.ListNode<int> {Value = 2};
            var last = new LinkedList<int>.ListNode<int> {Value = 3};

            list.AddFirst(first);
            list.AddLast(middle);
            list.AddLast(last);

            Assert.NotEmpty(list);
            Assert.Equal(3, list.Count);
            
            // Act
            var middleElement = list.GetAt(2);
            
            // Assert
            Assert.Equal(middle, middleElement);
        }

        [Fact]
        public void Should_RemoveAt2_from_list()
        {
            // Arrange
            var list = new LinkedList<int>();
            var first = new LinkedList<int>.ListNode<int> {Value = 1};
            var middle = new LinkedList<int>.ListNode<int> {Value = 2};
            var last = new LinkedList<int>.ListNode<int> {Value = 3};

            list.AddFirst(first);
            list.AddLast(middle);
            list.AddLast(last);

            Assert.NotEmpty(list);
            Assert.Equal(3, list.Count);

            // Act
            list.RemoveAt(2);

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Equal(first.Value, list.First().Value);
            Assert.Equal(last.Value, list.Last().Value);
        }

        [Fact]
        public void Should_get_positionOf_item_in_list()
        {
            // Arrange
            var list = new LinkedList<int>();
            var first = new LinkedList<int>.ListNode<int> {Value = 1};
            var middle = new LinkedList<int>.ListNode<int> {Value = 2};
            var last = new LinkedList<int>.ListNode<int> {Value = 3};

            list.AddFirst(first);
            list.AddLast(middle);
            list.AddLast(last);
            
            // Act
            var positionFirst = list.PositionOf(first.Value);
            var positionMiddle = list.PositionOf(middle.Value);
            var positionLast = list.PositionOf(last.Value);

            // Assert
            Assert.NotEmpty(list);
            Assert.Equal(3, list.Count);
            Assert.Equal(1, positionFirst);
            Assert.Equal(2, positionMiddle);
            Assert.Equal(3, positionLast);
        }
    }
}