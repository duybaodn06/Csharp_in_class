using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class Node
{
    public int Data;
    public Node Left;
    public Node Right;
}

public class BinaryTree
{
    public Dictionary<int, int> Pair = new Dictionary<int, int>();
    private Node Root;
    

    public void InsertAndCount(int value)
    {
        Node Before = null;
        Node After = this.Root;
        while (After != null)
        {
            Before = After;
            if (value < After.Data)
            {
                After = After.Left;
            }
            else if (value > After.Data)
            {
                After = After.Right;
            }
            else
            {
                Pair[value] ++ ;
                return;
            }
        }

        Node NewNode = new Node();
        NewNode.Data = value;
        if (this.Root == null)
        {
            this.Root = NewNode;
            Pair[value] = 1;
        }
        else
        {
            if (value < Before.Data)
            {
                Before.Left = NewNode;
                Pair[value] = 1;
            }
            else
            {
                Before.Right = NewNode;
                Pair[value] = 1;
            }

        }
    }
    public void TraverseIn()
    {
        TraverseInOrder(this.Root);
    }
    private void TraverseInOrder(Node Parent)
    {
        if (Parent != null)
        {
            TraverseInOrder(Parent.Left);
            Console.WriteLine(Parent.Data + ": " + Pair[Parent.Data]);
            TraverseInOrder(Parent.Right);
        }
    }
    public void TraversePre()
    {
        TraversePreOrder(this.Root);
    }
    private void TraversePreOrder(Node Parent)
    {
        if (Parent != null)
        {
            Console.WriteLine(Parent.Data + ": " + Pair[Parent.Data]);
            TraversePreOrder(Parent.Left);
            TraversePreOrder(Parent.Right);
        }
    }
    public void TraversePost()
    {
        TraversePostOrder(this.Root);
    }
    private void TraversePostOrder(Node Parent)
    {
        if (Parent != null)
        {
            TraversePostOrder(Parent.Left);
            TraversePostOrder(Parent.Right);
            Console.WriteLine(Parent.Data + ": " + Pair[Parent.Data]);
        }
    }
}


namespace Bai1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            BinaryTree btree = new BinaryTree();
            Random rnd = new Random(); 
            for (int i = 0; i < 10000; i++)
            {
                int x = rnd.Next(0,10);
                btree.InsertAndCount(x);
            }

            btree.TraverseIn();
            Console.WriteLine();
            btree.TraversePre();
            Console.WriteLine();
            btree.TraversePost();
            Console.WriteLine();

        }
    }
}
