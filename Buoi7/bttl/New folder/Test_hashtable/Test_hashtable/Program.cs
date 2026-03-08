using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_hashtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable newhash = new Hashtable(4);
            newhash.Add("Ten", "Nguyen Duy Bao");
            newhash.Add("MSSV", "31251027590");
            newhash.Add("Lop", "IT0001");
            newhash.Add("GPA", 3.9);
            foreach (string key in newhash.Keys)
            {
                Console.WriteLine(key + ": " + newhash[key]); 
            }

            


        }
    }
}
