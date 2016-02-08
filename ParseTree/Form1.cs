using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseTree
{
  public partial class Form1 : Form
  {
    Dictionary<int, List<Node>> levels;
    Node noderoot = null;

    public Form1()
    {
      InitializeComponent();

      levels = new Dictionary<int, List<Node>>();
      noderoot = new Node(1);
      
      noderoot.Left = new Node(2);
      noderoot.Right = new Node(3);

      noderoot.Left.Left  = new Node(4);
      //noderoot.Left.Right = new Node(5);
      noderoot.Right.Left = new Node(6);
      noderoot.Right.Right = new Node(7);



      FillRoot(noderoot, 1);
      collectNegbor();
      System.Diagnostics.Debug.WriteLine(noderoot.Left.Data + "->" + noderoot.Left.Neighbour.Data + "->" + noderoot.Left.Neighbour.Neighbour);
      System.Diagnostics.Debug.WriteLine(noderoot.Left.Left.Data + "->" + noderoot.Left.Left.Neighbour.Data + "->" + noderoot.Left.Left.Neighbour.Neighbour.Data + "->" + noderoot.Left.Left.Neighbour.Neighbour.Neighbour);
    }

    private void collectNegbor()
    {
      foreach (List<Node> level in levels.Values)
      {
        level.Add(null);
      }
      foreach (List<Node> level in levels.Values )
      {
        
        Node previouse = null;
        foreach (Node node in level)
        {
          if (previouse == null)
          {
            previouse = node;
          }
          else
          {
            previouse.Neighbour = node;
            previouse = node;
          }
        }
      }

    }

    private void FillRoot( Node node, int level)
    {

      if (node == null)
        return;
      if (node.Left == null && node.Right == null)
      {
        return;
      }
      if (levels.Keys.Contains(level) == false)
        levels.Add(level, new List<Node>());

      int NextLevel = level + 1;
      if (node.Left != null)
      {
        levels[level].Add(node.Left);
        Node nd= node.Left ;
        FillRoot( nd, NextLevel);
      }
      if (node.Right != null)
      {
        levels[level].Add(node.Right);
        Node nd= node.Right ;
        FillRoot( nd, NextLevel);
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
  }

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
