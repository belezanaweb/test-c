using System.Collections.Generic;

namespace Boticario.BelezaWeb.Domain.Notifications
{
	public class Notification
	{
		public IList<string> Errors { get; set; }

		public Notification()
		{
			Errors = new List<string>();
		}
	}
}
