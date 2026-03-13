
using System;
public class Vertex
{
    public bool WasVisited;
    public string Label;
    public Vertex(string label)
    {
        this.Label = label;
        WasVisited = false;
    }
}

public class Graph
{
    int NUM_VERTICES;
    int Num_Verts;
    Vertex[] Vertices;
    int[,] adjMatrix;

    public Graph(int num)
    {
        this.NUM_VERTICES = num;
        Num_Verts = 0;
        Vertices = new Vertex[NUM_VERTICES];
        adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
        for (int i = 0; i < NUM_VERTICES; i++)
        {
            for (int j = 0; j < NUM_VERTICES; j++)
            {
                adjMatrix[i, j] = 0;
            }
        }
    }

    public void AddVertex(string label)
    {
        Vertices[Num_Verts] = new Vertex(label);
        Num_Verts++;
    }

    public void AddEdge(int start, int end)
    {
        adjMatrix[start,end] = 1;
        adjMatrix[end, start] = 1;
    }

    public void AddEdgeAlpha(string x, string y)
    {
        int check = 0;
        int start = -1;
        int end = -1;
        for (int i = 0; i < NUM_VERTICES; i++)
        {
            if (x == Vertices[i].Label)
            {
                start = i;
                check++;
            }
            if (y == Vertices[i].Label)
            {
                end = i;
                check++;
            }
            if (check == 2) break;
        }
        if (check == 2)
        {
            adjMatrix[start, end] = 1;
            adjMatrix[end, start] = 1;
        }
        
    }

    public void ShowVertex(int x)
    {
        Console.Write(Vertices[x] + " ");
    }

    private int GetAdjUnvisitedVertex(int v)
    {
        for (int i = 0; i < NUM_VERTICES; i++)
        {
            if (Vertices[i].WasVisited == false && adjMatrix[v,i] == 1)
            {
                return i;
            }

        }
        return -1;
    }

    public void DepthFirstSearch()
    {
        Vertices[0].WasVisited = true;
        ShowVertex(0);
        Stack<int> gStack = new Stack<int>();
        gStack.Push(0);
        int v;
        while(gStack.Count > 0)
        {
            v = GetAdjUnvisitedVertex(gStack.Peek());
            if (v == -1)
            {
                gStack.Pop();
            }
            else
            {
                Vertices[v].WasVisited = true;
                ShowVertex(v);
                gStack.Push(v);
            }
        }

        for (int i = 0; i < NUM_VERTICES; ++i)
        {
            Vertices[i].WasVisited = false;
        }
    }

    public void BreadthFirstSearch()
    {
        Vertices[0].WasVisited = true;
        ShowVertex(0);
        Queue<int> gQueue = new Queue<int>();
        gQueue.Enqueue(0);
        int vert1, vert2;

        while (gQueue.Count > 0)
        {
            vert1 = gQueue.Dequeue();
            vert2 = GetAdjUnvisitedVertex(vert1);
            while (vert2 != -1)
            {
                Vertices[vert2].WasVisited = true;
                ShowVertex(vert2);
                gQueue.Enqueue(vert2);
                vert2 = GetAdjUnvisitedVertex(vert1);
            }
        }

        for (int i = 0; i < NUM_VERTICES; i++)
        {
            Vertices[i].WasVisited = false;
        }
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello");
    }
}

