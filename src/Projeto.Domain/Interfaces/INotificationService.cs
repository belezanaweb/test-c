using FluentValidation.Results;
using Projeto.Domain.Models;
using System.Collections.Generic;

namespace Projeto.Domain.Interfaces
{
    public interface INotificationService
    {
        bool HasNotification { get; }

        List<Notification> Notification { get; }

        void Add(string message);

        void Add(params ValidationFailure[] failures);
    }
}
