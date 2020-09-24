using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BelezaNaWeb.Framework.Extensions
{
    public static class StringExtensions
    {
        #region Private Static Fields

        static readonly char[,] accents = new char[,] {
              { 'a', 'á', 'à', 'ã', 'â', 'ä' }
            , { 'e', 'é', 'è', 'ê', 'ë', '\0' }
            , { 'i', 'í', 'ì', 'î', 'ï', '\0' }
            , { 'o', 'ó', 'ò', 'õ', 'ô', 'ö' }
            , { 'u', 'ú', 'ù', 'û', 'ü', '\0' }
            , { 'c', 'ç', '\0', '\0', '\0', '\0' }
            , { 'n', 'ñ', '\0', '\0', '\0', '\0' }
            , { 'y', 'ý', 'ÿ', '\0', '\0', '\0'}
            , { 'A', 'Á', 'À', 'Ã', 'Â', 'Ä' }
            , { 'E', 'É', 'È', 'Ê', 'Ë', '\0' }
            , { 'I', 'Í', 'Ì', 'Î', 'Ï', '\0' }
            , { 'O', 'Ó', 'Ò', 'Õ', 'Ô', 'Ö' }
            , { 'U', 'Ú', 'Ù', 'Û', 'Ü', '\0' }
            , { 'C', 'Ç', '\0', '\0', '\0', '\0' }
            , { 'N', 'Ñ', '\0', '\0', '\0', '\0' }
            , { 'Y', 'Ý', 'Ÿ', '\0', '\0', '\0'}
        };

        #endregion

        #region Extension Methods

        public static string RemoveMask(this string s)
            => Regex.Replace(s, "[^0-9]", "");

        public static string ToCNPJFormat(this string s)
            => Convert.ToUInt64(s).ToString(@"00\.000\.000\/0000\-00");

        public static string ToCPFFormat(this string s)
            => Convert.ToUInt64(s).ToString(@"000\.000\.000\-00");

        public static string ToUrlFormat(this string s)
            => s.ToUrlFormat('-');

        public static string ToUrlFormat(this string s, char escape)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;

            char last = escape;
            var array = new List<char>();
            var aux = s.Trim().Normalize(NormalizationForm.FormKC).ToLowerInvariant();

            foreach (var c in aux)
            {
                if (char.IsLetter(c))
                {
                    array.Add(c.RemoveAccent());
                    last = c;
                }
                else if (char.IsNumber(c))
                {
                    array.Add(c);
                    last = c;
                }
                else if (c == '&')
                {
                    array.Add('e');
                    last = 'e';
                }
                else if (last != escape)
                {
                    array.Add(escape);
                    last = escape;
                }
            }

            var i = array.Count;
            while (array[i - 1] == escape && i > 1)
                i--;

            return new string(array.Take(i).ToArray());
        }

        public static char RemoveAccent(this char c)
        {
            for (var i = 0; i < accents.GetLength(0); i++)
            {
                for (var j = 1; j < accents.GetLength(1); j++)
                {
                    if (accents[i, j] == '\0')
                        break;

                    if (c == accents[i, j])
                        return accents[i, 0];
                }
            }

            return c;
        }

        public static string RemoveAccents(this string s)
        {
            if (s == null)
                return null;
            var array = s.ToCharArray();
            for (var i = 0; i < array.Length; i++)
                array[i] = array[i].RemoveAccent();
            return new string(array);
        }

        public static string RemoveDots(this string s) => Regex.Replace(s, "[^0-9a-zA-Z]+", "");

        public static bool In(this string value, params string[] stringValues)
        {
            foreach (string otherValue in stringValues)
                if (string.Compare(value, otherValue) == 0)
                    return true;

            return false;
        }

        public static T ToEnum<T>(this string value) where T : struct
            => (T)Enum.Parse(typeof(T), value, true);

        public static string Right(this string value, int length)
            => (value != null && value.Length > length ? value.Substring(value.Length - length) : value);

        public static string Left(this string value, int length)
            => (value != null && value.Length > length ? value.Substring(0, length) : value);

        public static string Format(this string value, object arg0)
            => string.Format(value, arg0);

        public static string Format(this string value, params object[] args)
            => string.Format(value, args);

        public static bool IsNullOrEmpty(this string value)
            => string.IsNullOrEmpty(value);

        public static bool IsNullOrWhiteSpace(this string value)
            => string.IsNullOrWhiteSpace(value);

        public static bool EqualsIgnoreCase(this string value, string other)
            => value.Equals(other, StringComparison.OrdinalIgnoreCase);

        public static void ThrowIfNullOrEmpty(this string value, string argumentName = null)
        {
            if (value.IsNullOrEmpty())
                throw new ArgumentNullException(argumentName ?? nameof(value));
        }

        public static void ThrowIfNullOrWhiteSpace(this string value, string argumentName = null)
        {
            if (value.IsNullOrWhiteSpace())
                throw new ArgumentNullException(argumentName ?? nameof(value));
        }

        public static string WhenNullOrWhiteSpace(this string source, string value)
            => (string.IsNullOrWhiteSpace(source) ? value : source);

        public static string ReplaceKey(this string value, KeyValuePair<string, string> kvp)
        {
            if (value.IsNullOrEmpty()) return value;
            value = value.Replace(string.Concat("{", kvp.Key, "}"), kvp.Value);

            return value;
        }

        public static string ReplaceKeys(this string value, Dictionary<string, string> parameters)
        {
            if (parameters == null || !parameters.Any())
                return value;

            foreach (var item in parameters)
            {
                value = value.ReplaceKey(item);
            }

            return value;
        }

        public static string Base64Encode(this string plainText)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

        public static string Base64Decode(this string base64EncodedData)
            => Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));

        public static string Repeat(this char charToRepeat, int repeat)
            => new string(charToRepeat, repeat);

        public static string Repeat(this string stringToRepeat, int repeat)
        {
            var builder = new StringBuilder(repeat * stringToRepeat.Length);

            for (int i = 0; i < repeat; i++)
                builder.Append(stringToRepeat);

            return builder.ToString();
        }

        #endregion
    }
}
