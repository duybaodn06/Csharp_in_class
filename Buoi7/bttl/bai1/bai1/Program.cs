using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

public class User_Phone : DictionaryBase
{
    public void Add(string name, string phone)
    {
        this.InnerHashtable.Add(name, phone);
    }
    public string SearchByName(string name)
    {
        foreach (DictionaryEntry x in this.InnerHashtable)
        {
            if (x.Key.ToString() == name) return x.Value.ToString();
        }
        return null;
    }
    public string SearchByPhone(string phone)
    {
        foreach (DictionaryEntry x in this.InnerHashtable)
        {
            if (x.Value.ToString() == phone) return x.Key.ToString();
        }
        return null;
    }

    public void Remove(string name)
    {
        this.InnerHashtable.Remove(name);
    }
}

namespace bai1
{   
    internal class Program
    {
        static void Main(string[] args)
        {
            User_Phone x = new User_Phone();
            x.Add("Bao", "0795509206");
            x.Add("Huy", "0968988142");
            x.Add("Minh", "0775284206");
            x.Add("Dang", "0975479544");
            x.Add("Hieu", "0373992423");
            if (x.SearchByName("Minh") == null) Console.WriteLine("User not found");
            else Console.WriteLine(x.SearchByName("Minh"));
            if (x.SearchByPhone("0373992423") == null) Console.WriteLine("User not found");
            else Console.WriteLine(x.SearchByPhone("0373992423"));

        }
    }
}
