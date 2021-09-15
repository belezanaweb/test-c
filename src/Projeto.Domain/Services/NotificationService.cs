using FluentValidation.Results;
using Projeto.Domain.Interfaces;
using Projeto.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private readonly List<Notification> _notification;

        public NotificationService()
        {
            _notification = new List<Notification>();
        }

        public bool HasNotification { get => _notification.Any(); }

        public List<Notification> Notification { get => _notification; }

        public void Add(string message)
        {
            _notification.Add(new Notification(message));
        }

        public void Add(params ValidationFailure[] failures)
        {
            foreach (var failure in failures)
            {
               Add(failure.ErrorMessage);
            }
        }
    }
}
