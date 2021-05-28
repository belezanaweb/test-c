using NetHacksPack.Core;
using System.Collections.Generic;

namespace Inventory.Core.Data
{
    public interface IStorageRepository
    {
        Result<bool> Add<T>(T item);

        Result<bool> Update<T>(T item);

        Result<bool> Remove<T>(T item);
    }
}
