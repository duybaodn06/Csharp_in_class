using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

public class BucketHash
{
    private const int SIZE = 10;

    LinkedList<string>[] data;

    public BucketHash()
    {
        data = new LinkedList<string>[SIZE];
        for (int i = 0; i < SIZE; i++)
            data[i] = new LinkedList<string>();
    }
    public int Hash(string s)
    {
        //hash function
        long tot = 0;
        char[] chararray;
        chararray = s.ToCharArray();
        for (int i = 0; i <= s.Length - 1; i++) tot += 37 * tot + (int)chararray[i];
        tot = tot % data.GetUpperBound(0);
        if (tot < 0) tot += data.GetUpperBound(0);
        return (int)tot;
    }
    public void Insert(string item)
    {
        int hash_value = Hash(item);
        if (!data[hash_value].Contains(item))
            data[hash_value].AddLast(item);
    }
    public void Remove(string item)
    {
        int hash_value = Hash(item);
        if (data[hash_value].Contains(item)) data[hash_value].Remove(item);
    }
}




namespace HashTableInstall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "Minh";
            Console.WriteLine(new BucketHash().Hash(a));

        }
    }
}
