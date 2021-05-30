using Boticario.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.Domain.Handlers
{
    public class NotificatorHandler : INotification
    {

        private readonly List<Notification> _errors;


        public NotificatorHandler()
        {
            _errors = new List<Notification>();
        }



        public bool HasErrors()
        {
            return _errors.Any();
        }

        public void AddError(string error)
        {
            _errors.Add(new Notification(error));
        }
        public void AddErrors(List<string> errors)
        {
            foreach(var error in errors!=null ? errors : new List<string>())
                _errors.Add(new Notification(error));
        }

        public List<Notification> GetErrors()
        {
            return _errors;
        }

    }
}
