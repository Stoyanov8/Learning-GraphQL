using System.Collections;
using System.Collections.Generic;

namespace ASP.Core.GraphQL.Services.Repositories
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T GetById(int id);
    }
}
