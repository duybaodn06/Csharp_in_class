using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class Node
{
    public Node LeftNode;
    public Node RightNode;
    public int Data;
}

public class BinaryTree 
{
    private Node root;
    public bool Insert(int value)
    {
        Node before = null;
        Node after = this.root;
        while (after != null)
        {
            before = after;
            if (value < after.Data)
            {
                after = after.LeftNode;
            }
            else if (value > before.Data)
            {
                after = after.RightNode;
            }
            else return false;
        }
        Node NewNode = new Node();
        NewNode.Data = value;

        if (this.root == null)
        {
            this.root = NewNode;
        }
        else
        {
            if (value < before.Data) before.LeftNode = NewNode;
            else before.RightNode = NewNode;
        }
        return true;
    }
    public void TraverseIn()
    {
        TraverseInOrder(this.root);
    }
    private void TraverseInOrder(Node Parent)
    {
        if (Parent != null)
        {
            TraverseInOrder(Parent.LeftNode);
            Console.Write(Parent.Data + " ");
            TraverseInOrder(Parent.RightNode);
        }
    }
    public void TraversePre()
    {
        TraversePreOrder(this.root);
    }
    private void TraversePreOrder(Node Parent)
    {
        if (Parent != null)
        {
            Console.Write(Parent.Data + " ");
            TraversePreOrder(Parent.LeftNode);
            TraversePreOrder(Parent.RightNode);
        }
    }
    public void TraversePost()
    {
        TraversePostOrder(this.root);
    }
    private void TraversePostOrder(Node Parent)
    {
        if (Parent != null)
        {
            TraversePostOrder(Parent.LeftNode);
            TraversePostOrder(Parent.RightNode);
            Console.Write(Parent.Data + " ");
        }
    }

    public int FindMin()
    {
        Node current = this.root;
        while (current.LeftNode != null)
        {
            current = current.LeftNode;
        }
        return current.Data;
    }

    public int FindMax()
    {
        Node current = this.root;
        while (current.RightNode != null)
        {
            current = current.RightNode;
        }
        return current.Data;
    }

    public int GetTreeDepth()
    {
        return GetTreeDepth(this.root);
    }
    private int GetTreeDepth(Node node)
    {
        return node == null ? 0 : Math.Max(GetTreeDepth(node.LeftNode),GetTreeDepth(node.RightNode)) + 1;
    }

    public Node Find(int value)
    {
        return Find(value, this.root);
    }
    private Node Find(int value, Node current)
    {
        if (current != null)
        {
            if (value == current.Data) return current;
            else if (value >  current.Data) return Find(value,current.RightNode);
            else return Find(value, current.LeftNode);
        }
        return null;
    }
    private int MinValueOfNode(Node current)
    {
        while (current.LeftNode != null)
        {
            current = current.LeftNode;
        }
        return current.Data;
    }
    public void Remove(int value)
    {
        this.root = Remove(this.root, value);
    }
    private Node Remove(Node parent,int value)
    {
        if (parent == null) return null;
        if (parent.Data < value) parent.RightNode = Remove(parent.RightNode, value);
        else if (parent.Data > value) parent.LeftNode = Remove(parent.LeftNode, value);
        else
        {
            if (parent.LeftNode == null) return parent.RightNode;
            else if (parent.RightNode == null) return parent.LeftNode;
            parent.Data = MinValueOfNode(parent.RightNode);
            parent.RightNode = Remove(parent.RightNode, parent.Data);
        }
        return parent;
    }
}



namespace install
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.Insert(55);
            tree.Insert(30);
            tree.Insert(60);
            tree.Insert(22);
            tree.Insert(49);
            tree.Insert(58);
            tree.Insert(70);
            tree.Insert(11);
            tree.Insert(1);
            tree.TraverseIn();
            Console.WriteLine();
            tree.TraversePre();
            Console.WriteLine();
            tree.TraversePost();
            Console.WriteLine();

            
            Console.WriteLine(tree.FindMax());
            Console.WriteLine(tree.FindMin());

            Console.WriteLine(tree.GetTreeDepth());
            Console.WriteLine(tree.Find(11).Data);

            tree.Remove(30);
            tree.TraversePre();
            Console.WriteLine();

        }
    }
}
