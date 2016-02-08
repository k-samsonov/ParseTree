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

      noderoot.Left.Left = new Node(4);
      //noderoot.Left.Right = new Node(5);
      noderoot.Right.Left = new Node(6);
      noderoot.Right.Right = new Node(7);



      FillRoot(noderoot, 1);
      collectNegbor();
      string lnode1 = (noderoot.Neighbour == null) ? "null" : noderoot.Neighbour.ToString();
      string lnode2 = (noderoot.Left.Neighbour.Neighbour == null) ? "null" : noderoot.Left.Neighbour.Neighbour.ToString();
      string lnode3 = (noderoot.Left.Left.Neighbour.Neighbour.Neighbour == null) ? "null" : noderoot.Left.Left.Neighbour.Neighbour.Neighbour.ToString();
      listBox1.Items.Add(noderoot.Data.ToString() + "->" + lnode1);

      listBox1.Items.Add(noderoot.Left.Data.ToString() + "->" + noderoot.Left.Neighbour.Data.ToString() + "->" + lnode2);
      listBox1.Items.Add(noderoot.Left.Left.Data.ToString() + "->" + noderoot.Left.Left.Neighbour.Data + "->" + noderoot.Left.Left.Neighbour.Neighbour.Data.ToString() + "->" + lnode3);
    }

    private void collectNegbor()
    {
      foreach (List<Node> level in levels.Values)
      {
        level.Add(null);
      }
      foreach (List<Node> level in levels.Values)
      {

        Node previouse = null;
        foreach (Node node in level)
        {
          if (previouse != null)
          {
            previouse.Neighbour = node;
          }
          previouse = node;
        }
      }

    }

    private void FillRoot(Node node, int level)
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
        Node nd = node.Left;
        FillRoot(nd, NextLevel);
      }
      if (node.Right != null)
      {
        levels[level].Add(node.Right);
        Node nd = node.Right;
        FillRoot(nd, NextLevel);
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
