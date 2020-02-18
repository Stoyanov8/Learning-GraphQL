using System.Collections.Generic;
using ASP.Core.GraphQL.Database.Models;

namespace ASP.Core.GraphQL.Services.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllByCategory(int categoryId);

        bool Create(Product p);
    }
}
