using System.Collections.Generic;
using Wordania.Core.Identifiers;

namespace Wordania.Core.Services
{
    public interface IRegistry<T> where T:IEntity
    {
        int Count {get;}
        void Register(T entity);
        void Unregister(int entityId);
        IReadOnlyList<T> GetAll();
    }
}