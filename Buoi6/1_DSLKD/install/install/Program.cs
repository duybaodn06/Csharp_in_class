using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class Node
{
    public object element;
    public Node link;

    public Node()
    {
        element = null;
        link = null;
    }
    public Node(object element)
    {
        this.element = element;
        link = null;
    }
}

public class LinkedList
{
    private Node header;

    public LinkedList()
    {
        header = new Node("Header");
    }
    public void Push(object ele)
    {
        Node newNode = new Node(ele);
        newNode.link = header.link;
        header.link = newNode;
    }



    private Node Find(object element)
    {
        Node current = new Node();
        current = header;
        while (current.element != element)
        {
            current = current.link;
        }
        return current;
    }

    public void Insert(object newdata,object afterelement)
    {
        Node current = new Node();
        Node NewNode = new Node(newdata);
        current = Find(afterelement);
        NewNode.link = current.link;
        current.link = NewNode;
    }

    private Node FindPre(object element)
    {
        Node current = new Node();
        while (current.link.element != element && current.link != null)
        {
            current = current.link;
        }
        return current;
    }


    public void Remove(object element)
    {
        Node current = new Node();
        current = FindPre(element);
        if (current.link != null) current.link = current.link.link;
    }

    public int Count()
    {
        Node current = new Node();
        current = header;
        int count = 0;
        while (current.link != null)
        {
            current = current.link;
            count++;
        }
        return count;   
    }

    public int Sum()
    {
        Node current = header;
        int sum = 0;
        if (current.link != null)
        {
            while (Convert.ToInt32(current.link.element) is int)
            {
                sum += Convert.ToInt32(current.link.element);
                current = current.link;
                if (current.link == null) break;
            }
        }
        
        return sum;
    }

    public void Print()
    {
        Node current = new Node();
        current = header;
        while (current.link != null)
        {
            Console.WriteLine(current.link.element);
            current = current.link;
        }
    }

    //xđịnh nút có gtri max
    //tìm bộ ba pytago
}



namespace install
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.Insert("839", "Header");
            list.Insert("90", "839");
            list.Insert("80", "90");
            list.Print();
            Console.WriteLine(list.Count());
            list.Print();
            Console.WriteLine(list.Sum());
            //Console.WriteLine("===");
            //list.Remove("Second");
            //list.Print();
            //Console.ReadLine();

        }
    }
}
