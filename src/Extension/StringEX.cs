using System;
using System.Text.RegularExpressions;

namespace SharedCSharp.Extension
{
    public static class StringEX
    {
        /// <summary>
        /// 文字列を<see cref="Convert.ChangeType(object, Type)"/>で変換できる型に変換します。
        /// </summary>
        /// <typeparam name="T">変換する型</typeparam>
        /// <param name="defaultValue">変換できなかった場合に返される値</param>
        /// <param name="data">変換する<see cref="string"/></param>
        /// <returns>正常に変換された場合はその値、それ以外はdefaultValue</returns>
        public static T ParseTo<T>(this string str, T defaultValue)
            where T : IConvertible
        {
            if (!string.IsNullOrWhiteSpace(str) && Convert.ChangeType(str, typeof(T)) is T value)
            {
                return value;
            }

            return defaultValue;
        }

        public static string RemoveAll(this string str, string value)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string result = string.Empty;

            int offset = 0;
            Match match = new Regex(value).Match(str);
            while (match.Success)
            {
                result += str.Substring(offset, match.Index - offset);
                offset = match.Index + match.Length;
                match = match.NextMatch();
            }
            result += str.Substring(offset, match.Index - offset);

            return result;
        }
    }
}
