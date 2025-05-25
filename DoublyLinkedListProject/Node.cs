using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListProject
{
    public class Node
    {
        public double Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(double data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}
