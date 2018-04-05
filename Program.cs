using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McCluskey
{
    static class Program
    {
        static void Main(string[] args)
        {
            string raw_minterms = Input("Enter min-terms:");
            string raw_dontcares = Input("Enter dont cares:");
            int[] mins = Process(raw_minterms);
            int[] donts = Process(raw_dontcares);
            int variables = Variables(mins, donts);
            Console.WriteLine("Number of variables: " + variables.ToString());
            
            Console.ReadLine();
        }
        static T[] Concat<T>(this T[] x, T[] y)
        {
            T[] array = new T[x.Length + y.Length];
            x.CopyTo(array, 0);
            y.CopyTo(array, x.Length);
            return array;
        }
        static void Print<T>(T[] array,string splitter="")
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                Console.Write(array[i]);
                Console.Write(splitter);
            }
            Console.Write(array[array.Length - 1]);
        }
        static void PrintLine<T>(T[] array,string splitter = "")
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write(array[i]);
                Console.Write(splitter);
            }
            Console.WriteLine(array[array.Length - 1]);
        }
        static string Input(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        static int[] Process(string terms)
        {
            if (terms == "") return new int[0];
            return terms.Replace(" ", "").Split(",".ToCharArray()).Select(s => int.Parse(s)).ToArray();
        }
        static int Variables(int[] mins,int[] donts)
        {
            if (mins.Length + donts.Length < 1) return 1;
            int max = 0;
            foreach (int m in mins)
            {
                if (m > max)
                    max = m;
            }
            foreach (int d in donts)
            {
                if (d > max)
                    max = d;
            }
            return (int)Math.Ceiling(Math.Log(max+1, 2));
        }
        static byte[] ToBinary(int num)
        {
            List<Byte> list = new List<byte>();
            int rem = 0;
            while (num != 0)
            {
                num = Math.DivRem(num, 2,out rem);
                list.Insert(0, (byte)rem);
            }
            return list.ToArray();
        }
        static byte[] ToBinary(int num,int size)
        {
            byte[] bin = new byte[size];
            int rem = 0;
            for(int i = 0; i < size; i++)
            {
                if(num==0) break;
                num = Math.DivRem(num, 2, out rem);
                bin[size - i - 1] = (byte)rem;
            }
            return bin;
        }
        static int ToNum(byte[] bin)
        {
            int num = 0;
            for(int i = 0; i < bin.Length; i++)
            {
                num += bin[bin.Length - i - 1] * (int)Math.Pow(2, i);
            }
            return num;
        }

        static int[] ToMinterms(byte[] code)
        {
            int index = -1;
            for(int i = 0; i < code.Length; i++)
            {
                if (code[i] == 2)
                {
                    index = i;
                    break;
                }
            }
            if(index == -1)
            {
                return new int[] { ToNum(code) };
            }
            else
            {
                byte[] code0 = (byte[])code.Clone();
                byte[] code1 = (byte[])code.Clone();
                code0[index] = 0;
                code1[index] = 1;
                return Concat(ToMinterms(code0), ToMinterms(code1));
            }
        }
        static bool[][][] Solve(bool[][][] groups,out bool[][] primes)
        {
            List<bool[]> p = new List<bool[]>();
            List<bool[]>[] g = new List<bool[]>[groups.Length - 2];
            for(int i = 0; i < groups.Length - 2; i++)
            {

            }
        }
        static bool[][] Solve(bool[][] group1,bool[][] group2,out bool[][] primes)
        {

        }
    }
}
