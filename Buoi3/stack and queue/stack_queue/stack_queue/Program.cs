using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class node
{
    public node next;
    public object data;
}

public class mystack
{
    node top;

    public bool is_empty()
    {
        return top == null;
    }

    public void push(object ele)
    {
        node n = new node();   
        n.data = ele;
        n.next = top;
        top = n;
    }

    public node pop()
    {
        if (top == null) return null;
        node d = top;
        top = top.next;
        return d;
    }

    public int count(mystack ms)
    {
        int x = 0;
        List<object> li = new List<object>();
        while (!is_empty())
        {
            li.Add(ms.top.data);
            ms.pop();
            x++;
        }
        for (int i = 0; i < x; i++)
        {
            ms.push(li[i]);
        }
        return x;
    }

    public void reverse(mystack ms)
    {
        List<object> li = new List<object>();
        while (!is_empty())
        {
            li.Add(ms.top.data);
            ms.pop();
        }
        for (int i = 0; i < li.Count ; i++)
        {
            ms.push(li[i]);
        }
    }
}

public class node2
{
    public node2 pre, next;
    public object data;
}

public class myqueue
{
    node2 rear, front;
    public bool is_empty()
    {
        return rear == null;
    }

    public void enqueue(object ele)
    {
        node2 n = new node2();
        n.data = ele;
        if (rear == null)
        {
            rear = n; front = n;
        }
        else
        {
            rear.pre = n;
            n.next = rear;
            rear = n;
        }
    }

    public node2 dequeue()
    {
        if (front == null) return null;
        node2 n = front;
        front = front.pre;

        if (front == null) rear = null;
        else rear.next = null;
        return n;
    }

    public int count(myqueue mq)
    {
        int x = 0;
        List<object> li = new List<object>();
        while (!mq.is_empty())
        {

            li.Add(mq.dequeue().data);
            x++;
        }
        for (int i = 0; i < li.Count; i++)
        {
            enqueue(li[i]);
        }
        return x;
    }

    public void reverse(myqueue mq)
    {
        mystack newms = new mystack();
        while (!mq.is_empty())
        {
            newms.push(mq.dequeue().data);
        }
        while (!newms.is_empty())
        {
            mq.enqueue(newms.pop().data);
        }
    }
}

namespace stack_queue
{
    internal class Program
    {

        static void stack_actions(mystack ms)
        {
            Console.WriteLine(ms.is_empty());

            ms.push("acbj");
            ms.push(212);
            ms.push(122312);
            ms.push('a');

            Console.WriteLine(ms.count(ms));
            ms.reverse(ms);

            Console.WriteLine(ms.is_empty());
            Console.WriteLine(ms.pop().data);
            Console.WriteLine(ms.pop().data);
            Console.WriteLine(ms.pop().data);
            Console.WriteLine(ms.pop().data);
        }

        static void queue_actions(myqueue mq)
        {
            Console.WriteLine(mq.is_empty());

            mq.enqueue("abc");
            mq.enqueue("cde");
            mq.enqueue("efg");
            mq.enqueue("123");
            mq.enqueue("456");

            Console.WriteLine(mq.count(mq));
            Console.WriteLine(mq.is_empty());

            mq.reverse(mq);
            Console.WriteLine(mq.dequeue().data);
            Console.WriteLine(mq.dequeue().data);
            Console.WriteLine(mq.dequeue().data);
            Console.WriteLine(mq.dequeue().data);
            Console.WriteLine(mq.dequeue().data);

        }

        static void Main(string[] args)
        {
            //mystack ms = new mystack();
            //stack_actions(ms);
            
            myqueue mq = new myqueue();
            queue_actions(mq);

        }
    }
}
