#nullable disable
namespace HackerRank.Prepare.Software_Engineer_Prep_Kit.Easy._03_One_Pass_Removal_of_k_th_Node_from_End
{
    class Result
    {
        public static SinglyLinkedListNode removeKthNodeFromEnd(SinglyLinkedListNode head, int k)
        {
            return new SinglyLinkedListNode(6);

            //return null;
        }

    }

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }

        public static SinglyLinkedListNode CreateFromElements(int[] items)
        {
            if (items.Length == 0) return null;
            var head = new SinglyLinkedListNode(items[0]);

            var node = head;
            foreach (var item in items[1..])
            {
                var next = new SinglyLinkedListNode(item);
                node.next = next;
                node = next;
            }

            return head;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    class SinglyLinkedListPrintHelepr
    {
        public static void PrintList(SinglyLinkedListNode node, string sep)
        {
            while (node != null)
            {
                Console.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    Console.Write(sep);
                }
            }
        }
    }

}
