using System.Collections.Generic;

namespace Boticario.BelezaWeb.Domain.Extensions
{
	public static class StringExtensions
	{
		public static bool IsNullOrWhiteSpace(this string str)
		{
			return string.IsNullOrWhiteSpace(str);
		}

		public static List<string> ToListString(this string str)
		{
			return new List<string> {str};
		}
	}
}
