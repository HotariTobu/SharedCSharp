using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCSharp
{
    /// <summary>
    /// 整数値をキーとして関数を登録し、静的に呼び出せるようにするクラス。
    /// </summary>
    /// <remarks>キーは列挙型が想定されます。</remarks>
    public sealed class FuncCenter
    {
        /// <summary>
        /// 関数のコレクション
        /// </summary>
        private static readonly Dictionary<int, Func<object, object>> Funcs = new Dictionary<int, Func<object, object>>();

        private FuncCenter() { }

        /// <summary>
        /// 整数値をキーとして関数を登録します。
        /// </summary>
        /// <exception cref="Exception">キーがすでにコレクションに含まれていた場合</exception>
        /// <param name="key">登録する関数の識別に使われるキー</param>
        /// <param name="func">登録する関数</param>
        public static void AddFunc(int key, Func<object, object> func)
        {
            if (Funcs.ContainsKey(key))
            {
                throw new Exception($"key \"{key}\" はすでにコレクションに含まれていました。");
            }

            Funcs.Add(key, func);
        }

        /// <summary>
        /// 整数値をキーとして関数を呼び出します。
        /// </summary>
        /// <param name="key">呼び出す関数の識別に使われるキー</param>
        /// <param name="argument">呼び出す関数の引数</param>
        /// <param name="result">呼び出した関数の戻り値</param>
        /// <returns>正常に完了した場合はnull、それ以外は例外。</returns>
        public static Exception CallFunc(int key, object argument, out object result)
        {
            result = null;

            if (!Funcs.ContainsKey(key))
            {
                return new Exception($"key \"{key}\" はコレクションに含まれていませんでした。");
            }

            try
            {
                result = Funcs[key](argument);
            }
            catch (Exception e)
            {
                return e;
            }

            return null;
        }

        /// <summary>
        /// 整数値をキーとして関数を呼び出します。
        /// </summary>
        /// <param name="key">呼び出す関数の識別に使われるキー</param>
        /// <param name="argument">呼び出す関数の引数</param>
        /// <returns>正常に完了した場合はnull、それ以外は例外。</returns>
        public static Exception CallFunc(int key, object argument)
        {
            if (!Funcs.ContainsKey(key))
            {
                return new Exception($"key \"{key}\" はコレクションに含まれていませんでした。");
            }

            try
            {
                Funcs[key](argument);
            }
            catch (Exception e)
            {
                return e;
            }

            return null;
        }
    }
}
