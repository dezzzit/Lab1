using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Lab5_LockFreeLinkedList
{
    public class CustomLinkedList
    {
        private DNode _head;

        public DNode Head
        {
            get { return _head; }
            set { _head = value; }
        }

        public void AddFirst(int data)
        {
            DNode newNode = new DNode(data);
            newNode.Next = Head;
            newNode.Prev = null;
            if (Head != null)
            {
                Head.Prev = newNode;
            }
            Head = newNode;
        }

        public void AddFirstLockFree(int data)
        {
            DNode newNode;
            DNode chkNode;
            do
            {
                newNode = new DNode(data)
                {
                    Next = Head,
                    Prev = null
                };
                if (Head != null)
                {
                    Head.Prev = newNode;
                }

                chkNode = newNode;
                Interlocked.Exchange(ref _head, newNode);
            }
            while (newNode != Interlocked.CompareExchange(ref _head, chkNode, newNode));

        }

        public void AddLast(int data)
        {
            DNode newNode = new DNode(data);
            if (Head == null)
            {
                newNode.Prev = null;
                Head = newNode;
                return;
            }
            DNode lastNode = GetLastNode();
            lastNode.Next = newNode;
            newNode.Prev = lastNode;
        }

        public DNode GetLastNode()
        {
            DNode temp = Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }

        public DNode Tail => GetLastNode();



    }
}
