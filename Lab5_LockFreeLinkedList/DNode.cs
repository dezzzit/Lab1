namespace Lab5_LockFreeLinkedList
{
    public class DNode
    {

        public DNode(int d)
        {
            Data = d;
            Prev = null;
            Next = null;
        }

        public int Data { get; }
        public DNode Prev { get; set; }
        public DNode Next { get; set; }
    }
}
