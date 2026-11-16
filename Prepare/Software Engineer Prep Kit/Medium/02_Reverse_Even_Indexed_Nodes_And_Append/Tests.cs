using NUnit.Framework;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Medium._02_Reverse_Even_Indexed_Nodes_And_Append
{
    internal class Tests
    {
        private static SinglyLinkedListNode FromArray(int[] array)
        {
            if (array.Length == 0) return null;

            var head = new SinglyLinkedListNode(array[0]);
            var current = head;
            foreach (var x in array[1..])
            {
                var next = new SinglyLinkedListNode(x);
                current.next = next;
                current = next;
            }

            return head;
        }

        private static int[] ToArray(SinglyLinkedListNode node)
        {
            var list = new List<int>{ node.data };

            var currentNode = node;
            while(currentNode.next != null)
            {
                list.Add(currentNode.next.data);
                currentNode = currentNode.next;
            }

            return list.ToArray();
        }

        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 20, 40, 60, 50, 30, 10})]
        [TestCase(new int[] { 42 }, new int[] { 42 })]
        [TestCase(new int[] { 1,2 }, new int[] { 2,1 })]
        public void extractAndAppendSponsoredNodes(int[] input, int[] expectedResult) {
            var inputList = FromArray(input);
            var expectedResultList = FromArray(expectedResult);
            var result = Result.extractAndAppendSponsoredNodes(inputList);

            Assert.That(result, Is.Not.Null);
            Assert.That(ToArray(result), Is.EqualTo(ToArray(expectedResultList)));
        }
    }
}
