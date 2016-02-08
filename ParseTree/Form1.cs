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
    Dictionary<int, List<Node>> m_NodesByLevels;
    Node noderoot = null;

    public Form1()
    {
      InitializeComponent();
      m_NodesByLevels = new Dictionary<int, List<Node>>();

      CreateTree();
      CollectNeighbour(noderoot, 1);
      LinkNeighbourNodes();
      AddResultToList();
    }


    private void CreateTree()
    {
      noderoot = new Node(1);

      noderoot.Left = new Node(2);
      noderoot.Right = new Node(3);

      noderoot.Left.Left = new Node(4);
      //noderoot.Left.Right = new Node(5);
      noderoot.Right.Left = new Node(6);
      noderoot.Right.Right = new Node(7);
    }

    private void AddResultToList()
    {
      string lnode1 = (noderoot.Neighbour == null) ? "null" : noderoot.Neighbour.ToString();

      listBox1.Items.Add(noderoot.Data.ToString() + "->" + lnode1);
      string lnode2 = (noderoot.Left.Neighbour.Neighbour == null) ? "null" : noderoot.Left.Neighbour.Neighbour.ToString();

      listBox1.Items.Add(noderoot.Left.Data.ToString() + "->" + noderoot.Left.Neighbour.Data.ToString() + "->" + lnode2);

      string lnode3 = (noderoot.Left.Left.Neighbour.Neighbour.Neighbour == null) ? "null" : noderoot.Left.Left.Neighbour.Neighbour.Neighbour.ToString();
      listBox1.Items.Add(noderoot.Left.Left.Data.ToString() + "->" + noderoot.Left.Left.Neighbour.Data + "->" + noderoot.Left.Left.Neighbour.Neighbour.Data.ToString() + "->" + lnode3);
    }

    private void CollectNeighbour(Node node, int level)
    {
      if (NodeIsNullOrEmpty(node))
        return;

      AppendLevel(level);

      ProcessNodeOnLevel(node.Left, level);
      ProcessNodeOnLevel(node.Right, level);
    }

    private void LinkNeighbourNodes()
    {

      foreach (List<Node> level in m_NodesByLevels.Values)
      {
        ProcessLevel(level);
      }

    }

    private void ProcessLevel(List<Node> level)
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

    bool NodeIsNullOrEmpty(Node node)
    {
      bool res = false;
      if (node == null)
        res = true;
      if (node.Left == null && node.Right == null)
      {
        res = true;
      }
      return res;
    }

    private void AppendLevel(int level)
    {
      if (m_NodesByLevels.Keys.Contains(level) == false)
        m_NodesByLevels.Add(level, new List<Node>());
    }

    private void ProcessNodeOnLevel(Node node, int level)
    {
      if (node != null)
      {
        m_NodesByLevels[level].Add(node);
        CollectNeighbour(node, level + 1);
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
  }
}
