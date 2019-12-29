using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DumpSharp.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Foo f = createObject();
            Foo f = new Foo()
            {
                Property = 17,
                Bar = new Bar
                {
                    Bars = null,
                    Int = 17
                },
                String = "Test",
                List = new List<int>
                {
                    1, 2, 3
                }
            };

            Stopwatch sw = new Stopwatch();

            sw.Start();
            f.Dump();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Start();
            JsonConvert.SerializeObject(f);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.ReadKey();
        }

        private static Foo createObject()
        {
            return new Foo
            {
                Property = 10,
                String = getString(),
                Bar = getBar(20)
            };
        }

        private static string getString()
        {
            Random r = new Random();
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < 10000; i++)
            {
                sb.Append((char)r.Next(0, 255));
            }
            return sb.ToString();
        }

        private static Bar getBar(int depth = 0)
        {
            Bar b = new Bar
            {
                Int = depth
            };

            if(depth > 0)
            {
                b.Bars = new List<Bar>();
                for(int i = 0; i < depth; i++)
                {

                    b.Bars.Add(getBar(i - 1));
                }
            }
            return b;
        }
    }
}
