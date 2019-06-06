using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CustomLinkedList
    {
        private DNode _head;

        internal void AddFirst(int data)
        {
            DNode newNode = new DNode(data);
            newNode.Next = _head;
            newNode.Prev = null;
            if (_head != null)
            {
                _head.Prev = newNode;
            }
            _head = newNode;
        }

        internal void AddFirstLockFree(int data)
        {
            DNode newNode;
            DNode chkNode;
            do
            {
                newNode = new DNode(data)
                {
                    Next = _head,
                    Prev = null
                };
                if (_head != null)
                {
                    _head.Prev = newNode;
                }

                chkNode = newNode;
                Interlocked.Exchange(ref _head, newNode);
            }
            while (newNode != Interlocked.CompareExchange(ref _head, chkNode, newNode));

        }

        public void AddLast(int data)
        {
            DNode newNode = new DNode(data);
            if (_head == null)
            {
                newNode.Prev = null;
                _head = newNode;
                return;
            }
            DNode lastNode = GetLastNode();
            lastNode.Next = newNode;
            newNode.Prev = lastNode;
        }

        public DNode GetLastNode()
        {
            DNode temp = _head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }

    }
}
