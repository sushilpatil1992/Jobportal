
using System.Collections.Generic;
namespace JobPortalBVCOEK.DAL.Repositories
{
    public interface IBaseRepository<T>
    {
        void Add(T value);

        void Update(T value);

        void Delete(T value);
        T GetById(long id);
        IEnumerable<T> GetAll();
    }
}
