using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;

public class IPAddress:DictionaryBase
{
    public void Add(string name, string ip)
    {
        base.InnerHashtable.Add(name, ip);
    }
    public string Item(string name)
    {
        return base.InnerHashtable[name].ToString();
    }
    public void Remove(string name)
    {
        base.InnerHashtable.Remove(name);
    }
}

namespace Hash_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress myips = new IPAddress();
            myips.Add("Mike", "192.151.0.1");
            myips.Add("David", "192.151.0.2");
            myips.Add("Bernica", "192.151.0.3");
            Console.WriteLine("IP cua Mike la: " + myips.Item("Mike"));
            Console.WriteLine("\nkey va value la:");
            IDictionaryEnumerator e = myips.GetEnumerator();

            while (e.MoveNext()) { 
                Console.WriteLine("key={0},value={1}", e.Key, e.Value);
                
            }
            Console.ReadLine();


        }
    }
}
