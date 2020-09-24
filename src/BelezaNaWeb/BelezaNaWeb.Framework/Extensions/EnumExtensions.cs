using System.ComponentModel;

namespace BelezaNaWeb.Framework.Extensions
{
    public static class EnumExtensions
    {
        #region Extension Methods

        public static string ToDescription<TEnum>(this TEnum source)
        {
            var fi = source.GetType().GetField(source.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return source.ToString();
        }

        #endregion
    }
}
