using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedCSharp.Extension
{
    public static class CollectionEX
    {
        /// <summary>
        /// シーケンスから指定された全ての要素を削除したシーケンスを返します。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">元のシーケンス</param>
        /// <param name="value">削除する要素</param>
        /// <returns>指定された全ての要素が削除されたシーケンス</returns>
        public static IEnumerable<TSource> RemoveAll<TSource>(this IEnumerable<TSource> source, params TSource[] value)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            return source.Where(x => !value.Contains(x));
        }

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, Func<TSource, TSource, bool> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            foreach (TSource element in source)
            {
                if (comparer(value, element))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ContainsWithEqualsMethod<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            foreach (TSource element in source)
            {
                if (value.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public static IEnumerable<TSource> Swap<TSource>(this IEnumerable<TSource> source, int index1, int index2)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            TSource[] vs = source.ToArray();
            TSource temp = vs[index1];
            vs[index1] = vs[index2];
            vs[index2] = temp;

            return vs;
        }
    }
}
