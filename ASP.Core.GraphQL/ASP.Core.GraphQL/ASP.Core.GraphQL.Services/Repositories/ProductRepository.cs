using ASP.Core.GraphQL.Database;
using ASP.Core.GraphQL.Database.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASP.Core.GraphQL.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {

            this._context = context;
        }

        public IEnumerable<Product> GetAll()
            => this._context.Products.Include(x => x.Category);

        public Product GetById(int id)
            => this._context.Products
                .Include(x => x.Category)
                .SingleOrDefault(x => x.Id == id);

        public IEnumerable<Product> GetAllByCategory(int categoryId)
            => _context.Products.Include(x => x.Category).Where(x => x.CategoryId == categoryId);

        public bool Create(Product p)
        {
            _context.Products.Add(p);

            return _context.SaveChanges() > 0;
        }
    }
}
