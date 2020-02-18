using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Core.GraphQL.Database.Models;

namespace ASP.Core.GraphQL.Services.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Product> GetProductsByCategory(int categoryId);
    }
}
