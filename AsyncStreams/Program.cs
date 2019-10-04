using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AsyncStreams
{
    class Program
    {
        public static async Task Main(string[] args) //Main can be async since C#7
        {
            await foreach (var line in ReadLines())
            {
                Console.WriteLine(line);
            }
        }


        static async IAsyncEnumerable<string> ReadLines()
        {
            using var reader = new StreamReader(@"C:\Users\u12r23\Desktop\LoremIpsum"); //new in C#8
            while (!reader.EndOfStream)
            {
                yield return await reader.ReadLineAsync();
            }
        }
    }
}
