using System;
using System.Collections.Generic;
using System.Text;

namespace DumpSharp
{
    /// <summary>
    /// Extension class for dumping objects
    /// </summary>
    public static class DumpSharpExtensions
    {
        /// <summary>
        /// Prints the Dump output of <paramref name="o"/> to stdout
        /// </summary>
        /// <param name="o"></param>
        public static void Dump(this object o)
        {
            Console.WriteLine(ToDumpString(o));
        }

        /// <summary>
        /// Returns the Dump output of <paramref name="o"/>
        /// </summary>
        /// <param name="o">The object to dump</param>
        /// <returns></returns>
        public static string ToDumpString(this object o)
        {
            return ObjectDismantler.Dismantle(o);
        }
    }
}
