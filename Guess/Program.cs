using System;
using System.Collections.Generic;

namespace Guess
{
    public class Program
    {
        private static List<char[]> allCombos = new List<char[]> { };
        private static Names names = new Names();

        public static void Main(string[] args)
        {
            names.FetchList();

            //Console.WriteLine(names.allNames[1]);

            Combos(0, Blocks.allBlocks, "");
            foreach(char[] item in allCombos)
            {
                Permute(item, Output);
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void Combos(int pos, char[][] c, String soFar)
        {
            if (pos == c.Length)
            {
                //Console.WriteLine(soFar);
                allCombos.Add(soFar.ToCharArray());
                return;
            }
            for (int i = 0; i != c[pos].Length; i++)
            {
                Combos(pos + 1, c, soFar + c[pos][i]);
            }
        }

        private static void Output<T>(T[] permutation)
        {
            string tempName = "";

            //prints each character, looped, plus a newline at the end
            foreach (T item in permutation)
            {
                tempName += item;
            }
            foreach (string name in names.allNames)
            {
                if (tempName.ToUpper() == name.ToUpper())
                {
                    Console.WriteLine(tempName);
                }
                else
                {
                    Console.WriteLine("Nope");
                }
            }
        }

        public static void Permute<T>(T[] items, Action<T[]> output)
        {
            Permute(items, 0, new T[items.Length], new bool[items.Length], output);
        }

        private static void Permute<T>(T[] items, int item, T[] permutation, bool[] used, Action<T[]> output)
        {
            for (int i = 0; i < items.Length; ++i)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutation[item] = items[i];

                    if (item < (items.Length - 1))
                    {
                        Permute(items, item + 1, permutation, used, output);
                    }
                    else
                    {
                        output(permutation);
                    }

                    used[i] = false;
                }
            }
        }
    }
}
