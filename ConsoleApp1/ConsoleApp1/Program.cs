using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static ulong CollectEntropy()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 1000; i++)
            {
                Math.Sqrt(i);
            }

            sw.Stop();
            return (ulong)sw.ElapsedTicks;
        }

        static ulong MixBits(ulong x)
        {
            x ^= x << 13;
            x ^= x >> 7;
            x ^= x << 17;
            return x;
        }

        static uint GenerateRandom()
        {
            ulong entropy = CollectEntropy();
            ulong mixed = MixBits(entropy);
            return (uint)(mixed % uint.MaxValue);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("TERG Random Numbers:\n");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(GenerateRandom());
            }

            Console.ReadLine();
        }
    }
}
