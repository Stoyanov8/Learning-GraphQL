using ASP.Core.GraphQL.Database.Models;
using System.Collections.Generic;
using System.Linq;
using ASP.Core.GraphQL.Database;
using Microsoft.EntityFrameworkCore;

namespace ASP.Core.GraphQL.Services.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _context;

        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
            => _context.Categories.Include(x => x.Products);

        public Category GetById(int id)
            => _context.Categories.Include(x => x.Products).FirstOrDefault(x => x.Id == id);

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
            => _context.Products.Where(x => x.CategoryId == categoryId);

    }
}
