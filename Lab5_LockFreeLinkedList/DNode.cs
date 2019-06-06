using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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
