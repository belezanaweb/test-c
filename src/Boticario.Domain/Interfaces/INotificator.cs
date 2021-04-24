using Boticario.Domain.Entities;
using System.Collections.Generic;

namespace Boticario.Domain.Interfaces
{
    public interface INotificator
    {
        bool HasErrors();

        List<Notification> GetErrors();

        void AddError(string error);
    }
}