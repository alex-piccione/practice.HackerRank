using NUnit.Framework;

namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Easy._03_One_Pass_Removal_of_k_th_Node_from_End
{
    internal class Tests
    {
        [TestCase( new int[] { 5, 6, 7, 8 }, 3, 6)]
        [TestCase(new int[] { 5,1 }, 1, 1)]
        [TestCase(new int[] { 5 }, 1, 5)]
        [TestCase(new int[] { 1,2 }, 0, 1)]
        public void Test_not_null(int[] input, int k, int expectedHead)
        {
            SinglyLinkedListNode head = SinglyLinkedListNode.CreateFromElements(input);
            var result = Result.removeKthNodeFromEnd(head, k);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.data, Is.EqualTo(expectedHead));
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
