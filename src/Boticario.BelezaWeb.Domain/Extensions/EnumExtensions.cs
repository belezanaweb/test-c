using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Boticario.BelezaWeb.Domain.Extensions
{
	public static class EnumExtensions
	{
		public static string GetDisplayName(this Enum item)
		{
			var t = item.GetType();
			var info = t.GetField(item.ToString("G"));
			if (info is null)
				return string.Empty;

			var attr = info.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();
			return attr != null
				? ((DisplayAttribute) attr).Name
				: string.Empty;
		}

		public static string GetDescription(this Enum item)
		{
			var t = item.GetType();
			var info = t.GetField(item.ToString("G"));
			if (info is null)
				return string.Empty;

			var attr = info.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();
			return attr != null
				? ((DisplayAttribute) attr).Description
				: string.Empty;
		}
	}
}
