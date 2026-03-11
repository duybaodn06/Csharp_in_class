
using System;
using System.Collections;
using System.Collections.Generic;

public class Vertex
{
    public bool WasVisited;
    public string Label;
    public Vertex(string label)
    {
        this.Label = label;
    }
}

public class Graph
{
    private int NUM_VERTICES;
    private Vertex[] Vertices;
    private int[,] AdjVertices;
    private int NumVerts;

    public Graph(int number_of_vertex)
    {
        NUM_VERTICES = number_of_vertex;
        NumVerts = 0;
        Vertices = new Vertex[NUM_VERTICES];
        AdjVertices = new int[NUM_VERTICES, NUM_VERTICES];
        for (int i = 0; i < NUM_VERTICES; i++)
        {
            for (int j = 0; j < NUM_VERTICES; j++)
            {
                AdjVertices[i,j] = 0;
            }
        }
    }

    public void AddVertex(string label)
    {
        Vertices[NumVerts] = new Vertex(label);
        NumVerts++;
    }

    public void AddEdge(int start,int end)
    {
        AdjVertices[start,end] = 1;
        AdjVertices[start, end] = 1;
    }

    public void AddEdgeAlpha(string x, string y)
    {
        int i = -1;
        int j = -1;
        int count = 0;
        for (int k = 0; k < NumVerts; k++)
        {
            if (Vertices[k].Label == x)
            {
                i = k;
                count++;
            }
            if (Vertices[k].Label == y) {
                j = k;
                count++;
            }
            if (count == (1 << 1)) break;
        }

        if (i != -1 && j != -1)
        {
            AdjVertices[i, j] = 1;
            AdjVertices[j, i] = 1;
        }
    }

    public void ShowVertex(int v)
    {
        Console.WriteLine(Vertices[v].Label);
    }

    private int GetAdjUnvisitedVertex(int v)
    {
        for (int j = 0; j <= NUM_VERTICES - 1; j++)
        {
            if ((AdjVertices[v, j] == 1) && (Vertices[j].WasVisited == false)) return j;
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

        while (gStack.Count > 0)
        {
            v = GetAdjUnvisitedVertex(gStack.Peek());
            if (v == -1)
                gStack.Pop();
            else
            {
                Vertices[v].WasVisited = true;
                ShowVertex(v);
                gStack.Push(v);
            }
        }

        for (int j = 0; j <= NUM_VERTICES - 1; j++)
            Vertices[j].WasVisited = false;
    }

}





namespace Matrix1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(13);
            graph.AddVertex("A"); graph.AddVertex("B");//0 1
            graph.AddVertex("C"); graph.AddVertex("D");//2 3
            graph.AddVertex("E"); graph.AddVertex("F");//4 5
            graph.AddVertex("G"); graph.AddVertex("H");//6 7
            graph.AddVertex("I"); graph.AddVertex("J");//8 9
            graph.AddVertex("K"); graph.AddVertex("L");//10  11
            graph.AddVertex("M");//12
            //graph.AddEdgeAlpha("A", "B");
            graph.AddEdgeAlpha("A", "E");
            graph.AddEdgeAlpha("A", "H");
            graph.AddEdgeAlpha("A", "K");
            graph.AddEdgeAlpha("B", "C");
            graph.AddEdgeAlpha("C", "D");
            graph.AddEdgeAlpha("E", "F");
            graph.AddEdgeAlpha("F", "G");
            graph.AddEdgeAlpha("H", "I");
            graph.AddEdgeAlpha("I", "J");
            graph.AddEdgeAlpha("K", "L");
            graph.AddEdgeAlpha("L", "M");
            Console.Write("DFS: ");
            graph.DepthFirstSearch();
        }
    }
}
