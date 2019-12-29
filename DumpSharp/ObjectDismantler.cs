using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DumpSharp
{
    /// <summary>
    /// Class which helps to dismantle objects
    /// </summary>
    internal static class ObjectDismantler
    {
        /// <summary>
        /// Dismantles <paramref name="o"/> and returns the output
        /// </summary>
        /// <param name="o">The object to dismantle</param>
        /// <returns></returns>
        internal static string Dismantle(object o)
        {
            StringBuilder sb = new StringBuilder();
            dismantleRecursiv(o, sb);

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Dismanltes the given object <paramref name="o"/> recusivly
        /// </summary>
        /// <param name="o">Object to dismantle</param>
        /// <param name="sb">The current StringBuilder</param>
        /// <param name="currentLine">The current line</param>
        private static void dismantleRecursiv(object o, StringBuilder sb, string currentLine = null)
        {
            // If the object is null we can append null
            if(o == null)
            {
                append("NULL", currentLine, sb);
                return;
            }

            // If the object is a string we can append it's value directly
            if(o is string s)
            {
                append(s, currentLine, sb);
                return;
            }

            Type realType = o.GetType();

            // If it is an enum we write out the complete enum type
            if (realType.IsEnum)
            {
                append(realType.Name + "." + o.ToString(), currentLine, sb);
                return;
            }

            // If it is a value type we can call to string directly
            // This has to be done after the enum check, because a neum is a valuetype
            if (realType.IsValueType)
            {
                append(o.ToString(), currentLine, sb);
                return;
            }

            // If it is anything we can iterare over we do so here
            if (typeof(IEnumerable).IsAssignableFrom(realType))
            {
                IEnumerator x = (o as IEnumerable).GetEnumerator();

                int i = 0;
                while (x.MoveNext())
                {
                    dismantleRecursiv(x.Current, sb, currentLine + $"[{i}]");
                    i++;
                }
                return;
            }

            // If we have a "normal" class we can get all properties and read it's value
            if (realType.IsClass)
            {
                foreach (PropertyInfo prop in realType.GetProperties())
                {
                    string line = $"{realType.Name}.{prop.Name}";
                    dismantleRecursiv(prop.GetValue(o), sb, currentLine + line);
                }
                return;
            }
        }

        private static void append(string value, string currentLine, StringBuilder sb)
        {
            if(currentLine != null)
            {
                sb.Append(currentLine + " = ");
            }
            sb.AppendLine(value);
        }
    }
}
