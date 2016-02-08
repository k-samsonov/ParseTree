using System;
using System.Collections.Generic;
using System.Linq;

namespace ParseTree
{
  public class Node
  {
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node Neighbour { get; set; }
    public Node(int data)
    {

      Data = data;
    }

  }
}
