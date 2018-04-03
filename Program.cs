using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McCluskey
{
    class Program
    {
        static void Main(string[] args)
        {
            string raw_minterms = Input("Enter min-terms:");
            string raw_dontcares = Input("Enter dont cares:");
            int[] mins = Process(raw_minterms);
            int[] donts = Process(raw_dontcares);

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
    }
}
