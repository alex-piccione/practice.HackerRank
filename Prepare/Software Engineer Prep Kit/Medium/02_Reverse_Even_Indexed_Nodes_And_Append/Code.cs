
namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Medium._02_Reverse_Even_Indexed_Nodes_And_Append
{
    /*class SinglyLinkedListNode
    {
        int data;
        SinglyLinkedListNode next;
    }*/

    internal class SinglyLinkedListNode(int nodeData)
    {
        public int data { get;  } = nodeData;
        public SinglyLinkedListNode next { get; set; }
    }

    class Result
    {
        public static SinglyLinkedListNode FromArray(int[] array)
        {
            if (array.Length == 0) return null;

            var head = new SinglyLinkedListNode(array[0]);
            var current = head;
            foreach (var x in array[1..])
            {
                var next = new SinglyLinkedListNode (x);
                current.next = next;
                current = next;
            }

            return head;
        }

        public static SinglyLinkedListNode extractAndAppendSponsoredNodes(SinglyLinkedListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return head;

            var evenIndexedStack = new System.Collections.Generic.Stack<int>();
            var oddNodexQueue = new System.Collections.Generic.Queue<int>();

            var isEven = true;
            var node = head;
            do
            {
                if (isEven)
                    evenIndexedStack.Push(node.data);
                else
                {
                    oddNodexQueue.Enqueue(node.data);
                }

                node = node.next;
                isEven = !isEven;
            } while (node != null);

            SinglyLinkedListNode newHead = null;
            SinglyLinkedListNode lastNode = null;
            if (oddNodexQueue.Count > 0)
            {
                newHead = new SinglyLinkedListNode(oddNodexQueue.Dequeue());
                lastNode = newHead;
                while (oddNodexQueue.TryDequeue(out int nextData))
                {
                    lastNode.next = new SinglyLinkedListNode(nextData);
                    lastNode = lastNode.next;
                }
            }

            if (newHead == null)
            {
                newHead = new SinglyLinkedListNode(evenIndexedStack.Pop());
                lastNode = newHead;
            }
            while (evenIndexedStack.TryPop(out int nextData)) {

                lastNode.next = new SinglyLinkedListNode(nextData);
                lastNode = lastNode.next;
            }

            return newHead;
        }
    }
}
