using System;
using System.Collections.Generic;

namespace WPConsole {
    public static class WPStringExtensions {
        public static bool StartsWith(this string src_str, string find_str, bool ignoreCase = false) {
            StringComparison type = ignoreCase ?
                StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            return src_str.StartsWith(find_str, type);
        }

        public static string Join(this string[] rows, string separator) {
            return String.Join(separator, rows);
        }
        public static string Join(this List<string> rows, string separator) {
            return String.Join(separator, rows);
        }

        /// <summary> ForEach extension include index management
        ///     <example> 
        ///         <code>
        ///             example:<br/> 
        ///             var people = new[] { "Moe", "Curly", "Larry" };<br/>
        ///             people.ForEach((i, p) => Console.WriteLine("Person #{0} is {1}", i, p));
        ///         </code>
        ///     </example>
        /// </summary>
        public static int ForEach<T>(this IEnumerable<T> list, Action<int, T> action) {
            if (action == null) throw new ArgumentNullException("action");

            var index = 0;

            foreach (var elem in list)
                action(index++, elem);

            return index;
        }

        /// <summary> ForEach extension
        ///     <example> 
        ///         <code>
        ///             example:<br/> 
        ///             books_data.ForEach(str => AddBookToContainer("installed", str));
        ///         </code>
        ///     </example>
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (T element in source)
                action(element);
        }
    }
}
