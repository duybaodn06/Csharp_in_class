using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class Dictionary
{
    private const int SIZE = 10;
    LinkedList<string>[] data;
    public Dictionary()
    {
        data = new LinkedList<string>[SIZE];
        for (int i = 0; i < SIZE; i++)
        {
            data[i] = new LinkedList<string>();
        }
    }

    public int Hash(string s)
    {
        s = s.ToLower();
        long tot = 0;
        char[] arraylist = s.ToCharArray();
        for (int i = 0; i < arraylist.Length;i++)
        {
            tot = tot * 31 + arraylist[i];
        }
        tot %= SIZE;
        if (tot < 0) tot += SIZE;
        return (int)tot;
    }

    public void Insert(string s)
    {
        s = s.ToLower();
        int val = Hash(s);
        if (!data[val].Contains(s)) data[val].AddLast(s);
    }

    public void Remove(string s)
    {
        s = s.ToLower();
        int val = Hash(s);
        if (data[val].Contains(s)) data[val].Remove(s);
    }

    public bool Check (string s)
    {
        s = s.ToLower();
        int val = Hash(s);
        string sing = "";
        if (s[s.Length - 1] == 's')
        {
            sing = s.Remove(s.Length - 1);
            int val_sing = Hash(sing);
            if (data[val_sing].Contains(sing)) return true;
        }
        

        
        if (data[val].Contains(s)) return true;
        else return false;
    }
}



namespace bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary dc = new Dictionary();
            dc.Insert("Government");
            dc.Insert("Adverse");
            dc.Insert("Prototype");
            dc.Insert("Classification");
            dc.Insert("Stereotype");
            dc.Insert("Friend");

            string[] s = { "Govenment", "Advet", "prototype","classifications", "stereotyp", "fRiEnDs"};

            foreach (string x in s)
            {
                if (dc.Check(x)) Console.WriteLine(x.ToLower());
            }


        }
    }
}
