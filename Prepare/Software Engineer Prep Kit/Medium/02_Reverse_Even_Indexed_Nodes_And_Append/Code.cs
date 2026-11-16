
namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Medium._02_Reverse_Even_Indexed_Nodes_And_Append
{
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
            if (head == null || head.next == null) return head;

            var evenIndexedStack = new System.Collections.Generic.Stack<int>(); // allows to pick in reverse order
            var oddQueue = new System.Collections.Generic.Queue<int>();

            // Loop the items and put in the Stack (event-indexed ones) or in the Queue
            var isEven = true;
            var node = head;
            do
            {
                if (isEven) evenIndexedStack.Push(node.data);
                else oddQueue.Enqueue(node.data);

                node = node.next;
                isEven = !isEven;
            } while (node != null);

            // Compose the linked list using the Queue...
            SinglyLinkedListNode newHead = null;
            SinglyLinkedListNode lastNode = null;
            if (oddQueue.Count > 0)
            {
                newHead = new SinglyLinkedListNode(oddQueue.Dequeue());
                lastNode = newHead;
                while (oddQueue.TryDequeue(out int nextData))
                {
                    lastNode.next = new SinglyLinkedListNode(nextData);
                    lastNode = lastNode.next;
                }
            }

            // ... and then the Stack
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
