using System.Threading.Tasks;
using ASP.Core.GraphQL.Database.Models;
using ASP.Core.GraphQL.Services.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace ASP.Core.GraphQL.Client.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            this.Field(t => t.Id);
            this.Field(t => t.Name);
            this.Field(t => t.Available);
            this.Field(t => t.Count);
            this.Field<CategoryType>("category", resolve: context => context.Source.Category);

            this.Field(name: "categoryName", t => t.Category.Name);
            this.Field(name: "hardcoded", t => 1);
        }
    }
}
