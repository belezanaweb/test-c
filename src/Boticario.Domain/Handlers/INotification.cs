using Boticario.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Domain.Handlers
{
    public interface INotification
    {
   
            bool HasErrors();

            List<Notification> GetErrors();

            void AddError(string error);
            void AddErrors(List<string> error);

    }
}
