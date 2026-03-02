using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

struct Pair 
{
    private int first;
    private int second;
    public void setPair(int a,int b)
    {
        this.first = a;
        this.second = b;
    }
    public void setFirst(int a)
    {
        this.first = a;
    }
    public int getFirst()
    {
        return first;
    }
    public int getSecond()
    {
        return second;
    }

}


namespace stability
{
    internal class Program
    {
        static void bubble_sort(Pair[] Test)
        {
            int n = Test.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool check = true;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (Test[j].getFirst() > Test[j + 1].getFirst())
                    {
                        Pair temp = Test[j];
                        Test[j] = Test[j + 1];
                        Test[j + 1] = temp;
                        check = false;
                    }
                }
                if (check) break;
            }
        }
        static void Main(string[] args)
        {
            //create array Pair
            Pair[] Test = new Pair[100000];

            //set first element and mark second element
            Random rnd = new Random();
            for (int i = 0; i < Test.Length; i++)
            {
                Test[i].setPair(10, i);
            }

            //set 1% left 
            for (int i = 0; i < 0.01 * Test.Length; i++)
            {
                int x = rnd.Next(1,100);
                Test[i].setFirst(x);
            }


            //sort
            bubble_sort(Test);

            ////print
            //for (int i = 0; i < Test.Length; i++)
            //{
            //    Console.WriteLine($"({Test[i].getFirst()},{Test[i].getSecond()}) ");
            //}

            //Create a bool to check if it is stable

            bool check = true;
            for (int i = 1; i < Test.Length; i++)
            {
                if (Test[i - 1].getFirst() == Test[i].getFirst() && Test[i - 1].getSecond() > Test[i].getSecond())
                {
                    check = false;
                    break;
                }
            }
            Console.WriteLine(check);
        }
    }
}
