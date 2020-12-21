using System;
using System.Collections.Generic;

namespace Extensions.SystemExt.CollectionsExt
{
    public static class ReadOnlyListExt
    {
        public static void ForEach<T>(
            this IReadOnlyList<T> list,
            Action<T> action)
        {
            using (var enumeratior = list.GetEnumerator())
            {
                while (enumeratior.MoveNext())
                {
                    action(enumeratior.Current);
                }
            }
        }

        public static IReadOnlyList<TResult> Select<T, TResult>(
            this IReadOnlyList<T> list,
            Func<T, TResult> func)
        {
            var returnList = new List<TResult>();
            using (var enumeratior = list.GetEnumerator())
            {
                while (enumeratior.MoveNext())
                {
                    returnList.Add(func(enumeratior.Current));
                }
            }

            return returnList;
        }
    }
}
