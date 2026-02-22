using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Bai_1
{
    internal class Program
    {
        static T reverse<T>(ref T val1)
        {

            if (typeof(T) == typeof(int))
            {
                int res = 0;
                int copy = (dynamic)val1;
                while (copy > 0)
                {
                    int a = (dynamic)copy % 10;
                    res = res * 10 + a;
                    copy /= 10;

                }
                return (dynamic)res;
            }
            else if (typeof(T) == typeof(string))
            {
                dynamic str = val1;
                dynamic res = "";
                foreach (char v in str)
                {
                    res = v + res;
                }
                return res;
            }
            else if (typeof(T) == typeof(Array))
            {
                dynamic a = val1;
                return Array.Reverse(a);
            }
            return val1;
        }

        static void Main(string[] args)
        {
            int a = 123452;
            reverse<int>(ref a);

            string b = "abc";
            reverse<string>(ref b);

            int[] c = { 1, 2, 3, 4 };
            
            Console.WriteLine(reverse<int>(ref a));
            Console.WriteLine(reverse<string>(ref b));

            foreach (int x in reverse<int[]>(ref c))
            {
                Console.Write(x + " ");
            }
            
        }


    }
}
