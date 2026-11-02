using NUnit.Framework;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Easy._03_One_Pass_Removal_of_k_th_Node_from_End
{
    internal class Tests
    {
        [TestCase(new int[] { 5, 6, 7, 8 }, 3, new int[] { 6, 7, 8 })]
        [TestCase(new int[] { 5, 6, 7, 8 }, 2, new int[] { 5, 7, 8 })]
        [TestCase(new int[] { 5, 1 }, 1, new int[] {1})]
        [TestCase(new int[] { 5 }, 1, new int[] { 5 })]
        [TestCase(new int[] { 1, 2 }, 0, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 1, 2, 3 })]
        public void Test_not_null(int[] input, int k, int[] expectedValues)
        {
            var head = SinglyLinkedListNode.CreateFromElements(input);
            var result = Result.removeKthNodeFromEnd(head, k);

            var expectedNewHead = SinglyLinkedListNode.CreateFromElements(expectedValues);

            Assert.That(result, Is.Not.Null);

            Assert.That(result.data, Is.EqualTo(expectedNewHead.data));
            var expectedNext = expectedNewHead.next;
            var resultNext = result.next;
            while (expectedNext != null)
            {
                Assert.That(resultNext, Is.Not.Null);
                Assert.That(resultNext.data, Is.EqualTo(expectedNext.data));
                expectedNext = expectedNext.next;
                resultNext = resultNext.next;
            }

            // check there are not extra elements
            Assert.That(resultNext, Is.Null);
        }

        [TestCase(new int[] {}, 3)]
        [TestCase(new int[] { 5 }, 0)]
        public void Test_null(int[] input, int k)
        {
            SinglyLinkedListNode head = SinglyLinkedListNode.CreateFromElements(input);
            var result = Result.removeKthNodeFromEnd(head, k);

            Assert.That(result, Is.Null);
        }
    }
}
