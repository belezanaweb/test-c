using Boticario.Domain.Entities;
using Boticario.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.Domain.Handlers
{
    public class NotificatorHandler : INotificator
    {
        #region Properties

        private readonly List<Notification> _errors;

        #endregion

        #region Constructors

        public NotificatorHandler()
        {
            _errors = new List<Notification>();
        }

        #endregion

        #region Public Methods

        public bool HasErrors()
        {
            return _errors.Any();
        }

        public void AddError(string error)
        {
            _errors.Add(new Notification(error));
        }

        public List<Notification> GetErrors()
        {
            return _errors;
        }

        #endregion
    }
}