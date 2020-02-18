using System;
using System.Linq;
using System.Threading.Tasks;
using ASP.Core.GraphQL.Database.Models;
using ASP.Core.GraphQL.Services.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace ASP.Core.GraphQL.Client.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(ICategoryRepository repository)
        {
            Field(t => t.Id);
            Field(t => t.Name);

            Field<ListGraphType<ProductType>>("products", resolve: context => repository.GetProductsByCategory(context.Source.Id));
        }
    }
}
