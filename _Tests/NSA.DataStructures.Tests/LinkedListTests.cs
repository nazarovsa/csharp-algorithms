using System.Linq;
using Xunit;

namespace NSA.DataStructures.Tests
{
    public class LinkedListTests
    {
        [Fact]
        public void Should_AddFirst_and_AddLast_to_list()
        {
            var list = new LinkedList<int>();
            var first = new LinkedList<int>.ListNode<int> {Value = 1};
            var last = new LinkedList<int>.ListNode<int> {Value = 2};
            
            list.AddFirst(first);
            list.AddLast(last);

            Assert.NotEmpty(list);
            Assert.Equal(2, list.Count);
            Assert.Equal(first.Value, list.First().Value);
            Assert.Equal(last.Value, list.Last().Value);
        }
        
        [Fact]
        public void Should_Reverse_list()
        {
            var list = new LinkedList<int>();
            var first = new LinkedList<int>.ListNode<int> {Value = 1};
            var last = new LinkedList<int>.ListNode<int> {Value = 2};
            
            list.AddFirst(first);
            list.AddLast(last);

            list.Reverse();

            Assert.NotEmpty(list);
            Assert.Equal(2, list.Count);
            Assert.Equal(last.Value, list.First().Value);
            Assert.Equal(first.Value, list.Last().Value);
        }
        
        [Fact]
        public void Should_GetAt2_from_list()
        {
            var list = new LinkedList<int>();
            var first = new LinkedList<int>.ListNode<int> {Value = 1};
            var middle = new LinkedList<int>.ListNode<int> {Value = 2};
            var last = new LinkedList<int>.ListNode<int> {Value = 3};
            
            list.AddFirst(first);
            list.AddLast(middle);
            list.AddLast(last);

            Assert.NotEmpty(list);
            Assert.Equal(3, list.Count);

            var middleElement = list.GetAt(2);
            Assert.Equal(middle, middleElement);
        }
        
        [Fact]
        public void Should_RemoveAt2_from_list()
        {
            var list = new LinkedList<int>();
            var first = new LinkedList<int>.ListNode<int> {Value = 1};
            var middle = new LinkedList<int>.ListNode<int> {Value = 2};
            var last = new LinkedList<int>.ListNode<int> {Value = 3};
            
            list.AddFirst(first);
            list.AddLast(middle);
            list.AddLast(last);

            Assert.NotEmpty(list);
            Assert.Equal(3, list.Count);

            list.RemoveAt(2);
            
            Assert.Equal(2, list.Count);
            Assert.Equal(first.Value, list.First().Value);
            Assert.Equal(last.Value, list.Last().Value);
        }
    }
}