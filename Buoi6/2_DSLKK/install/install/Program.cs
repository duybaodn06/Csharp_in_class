using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class Node
{
    public object element;
    public Node flink, blink;
    public Node()
    {
        element = null;
        flink = blink = null;
    } 
    public Node(object element)
    {
        this.element = element;
        flink = blink = null;
    }
}

public class DoubleLinkedList
{
    public Node header;

    public DoubleLinkedList()
    {
        header = new Node("Header");
    }

    public Node Find(object afterelement)
    {
        Node current = header;
        while (current.element != afterelement)
        {
            current = current.flink;
        }
        return current;
    }

    public void Insert(object newelement, object afterelement)
    {
        Node current = new Node();
        Node NewNode = new Node(newelement);
        current = Find(afterelement);
        if (current.flink  != null)
        {
            current.flink.blink = NewNode;
        }
        NewNode.flink = current.flink;
        current.flink = NewNode;
        NewNode.blink = current;
    }

    public void Remove(object element)
    {
        Node current = Find(element);
        if (current.flink != null)
        {
            current.blink.flink = current.flink;
            current.flink.blink = current.blink;
            current.flink = null;
            current.blink = null;
        }
    }

    private Node FindLast()
    {
        Node current = new Node();
        current = header;
        while (!(current.flink == null)) current = current.flink;
        return current;
    }

    public int Count()
    {
        int count = 0;
        Node current = FindLast();
        while (current.blink != null)
        {
            current = current.blink;
            count++;
        }
        return count;
    }
    public int Sum()
    {
        int count = 0;
        Node current = FindLast();
        while (current.blink != null)
        {
            count += Convert.ToInt32(current.element);
            current = current.blink;
        }
        return count;
    }


    public void Print()
    {
        Node current = header;
        while (current.flink != null)
        {
            Console.WriteLine(current.flink.element);
            current= current.flink;
        }
    }
    public int Max()
    {
        Node current = header;
        int max = Convert.ToInt32(current.flink.element);
        while (current.flink != null)
        {
            if (max < Convert.ToInt32(current.flink.element)) max = Convert.ToInt32(current.flink.element);
            current = current.flink;
        }
        return max;
    }

    public int[] Pythago()
    {
        int[] res = new int[3];
        Node current = header.flink;
        bool check = false;
        while (current.flink.flink != null)
        {
            int a = Convert.ToInt32(current.element);
            int b = Convert.ToInt32(current.flink.element);
            int c = Convert.ToInt32(current.flink.flink.element);
            if ((a*a + b*b == c*c) || Math.Abs(a*a - b*b) == c*c)
            {
                check = true;
                break;
            }
            current = current.flink;
        }
        if (check)
        {
            res[0] = Convert.ToInt32(current.element);
            res[1] = Convert.ToInt32(current.flink.element);
            res[2] = Convert.ToInt32(current.flink.flink.element);
        }
        else res[0] = -1;
        return res;
    }

}



namespace install
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList a = new DoubleLinkedList();
            a.Insert("123", "Header");
            a.Insert("456", "123");
            a.Insert("90", "456");
            a.Insert("1000", "90");
            a.Insert("20", "1000");
            a.Insert("3", "20");
            a.Insert("5", "3");
            a.Insert("4", "5");
            Console.WriteLine(a.Count());
            a.Print();
            Console.WriteLine(a.Sum());
            Console.WriteLine(a.Max());
            if (a.Pythago()[0] != -1)
            {
                Console.Write(a.Pythago()[0] + " ");
                Console.Write(a.Pythago()[1] + " ");
                Console.WriteLine(a.Pythago()[2]);
            }

        }
    }
}
