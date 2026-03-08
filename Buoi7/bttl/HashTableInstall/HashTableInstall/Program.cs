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
        {
            data[i] = new LinkedList<string>();
        }
    }
    public int Hash(string s)
    {
        long tot = 0;
        char[] arraylist = s.ToCharArray();
        for (int i = 0; i < arraylist.Length;i++)
        {
            tot += 37 * tot + (int)arraylist[i];
        }
        tot %= SIZE - 1;
        if (tot < 0) tot += (SIZE - 1);
        return (int)tot;
    }

    public void Insert(string s)
    {
        int hash_value = Hash(s);
        if (!data[hash_value].Contains(s)) data[hash_value].AddLast(s);
    }
    
    public void Remove(string s)
    {
        int hash_value = Hash(s);
        if (data[hash_value].Contains(s)) data[hash_value].Remove(s);
    }
}



namespace HashTableInstall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

        }
    }
}
