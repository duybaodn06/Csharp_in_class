using System;
using System.Collections.Generic;

public class Program
{
    public class WebBrowser
    {
        public string title;
        public DateTime last_visited;
        public string url;
        public WebBrowser(string title, DateTime last_visited, string url)
        {
            this.title = title;
            this.last_visited = last_visited;
            this.url = url;
        }
        public override string ToString()
        {
            return $"{last_visited:yyyy-MM-dd HH:mm:ss} | {title} {url}";
        }
    }
    public class Node
    {
        public WebBrowser data;
        public Node next;
        public Node(WebBrowser x)
        {
            data = x;
            next = null;
        }
    }
    public class WebBrowserHistory
    {
        Node top;

        public bool IsEmpty()
        {
            return top == null;
        }
        public void Push (WebBrowser newbrowser)
        {
            Node NewNode = new Node(newbrowser);
            NewNode.next = top;
            top = NewNode;
        }

        public WebBrowser Pop()
        {
            Node NewNode = top;
            top = top.next;
            return NewNode.data;
        }

        public List<WebBrowser> ToList()
        {
            List<WebBrowser> NewList = new List<WebBrowser>();
            Node Current = top;//thừa
            while (!IsEmpty())
            {
                NewList.Add(Pop());
            }
            foreach (WebBrowser x in NewList) Push(x);
            return NewList; 

        }

        public void Swap(WebBrowser a, WebBrowser b)
        {
            WebBrowser temp = new WebBrowser(a.title, a.last_visited, a.url); ;
            a.title = b.title; a.last_visited = b.last_visited; a.url = b.url;
            b.title = temp.title; b.last_visited = temp.last_visited; b.url = temp.url;
        }


        public List<WebBrowser> Sort()
        {
            List<WebBrowser> li = ToList();
            for (int j = 0; j <= li.Count - 2; j++)
            {
                for (int i = j + 1; i <= li.Count- 1; i++)
                {
                    if (li[i].last_visited.CompareTo(li[j].last_visited) > 0)
                    {
                        Swap(li[i], li[j]);
                    }
                }
            }
            return li;
        }
    }
    public static void Main(string[] args)
    {


        Random rnd = new Random();
        WebBrowserHistory WebHistory = new WebBrowserHistory();


        string[] sites = { "Google", "Facebook", "LMS", "GitHub", "Youtube" };
        for (int i = 0; i < 5; i++)
        {
            DateTime randomDate = new DateTime(
                rnd.Next(2020, 2026), rnd.Next(1, 13), rnd.Next(1, 28),
                rnd.Next(0, 24), rnd.Next(0, 60), rnd.Next(0, 60)
            );
            WebHistory.Push(new WebBrowser(sites[i], randomDate, sites[i].ToLower() + ".com"));
        }
        WebBrowserHistory sortedHistory = new WebBrowserHistory();


        List<WebBrowser> HistoryList = WebHistory.Sort();
        for (int i = HistoryList.Count - 1; i >= 0; i--)
        {
            WebHistory.Push(HistoryList[i]);
        }

        foreach (var item in HistoryList)
        {
            Console.WriteLine(item.ToString());
        }

        Console.ReadLine();
    }
}
