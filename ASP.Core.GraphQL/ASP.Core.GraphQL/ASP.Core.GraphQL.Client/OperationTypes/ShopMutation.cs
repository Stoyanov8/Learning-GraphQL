using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ASP.Core.GraphQL.Client.Types;
using ASP.Core.GraphQL.Database.Models;
using ASP.Core.GraphQL.Services.Repositories;
using GraphQL.Types;

namespace ASP.Core.GraphQL.Client.OperationTypes
{
    public class ShopMutation : ObjectGraphType
    {
        public ShopMutation(IProductRepository productRepository)
        {
            FieldAsync<BooleanGraphType>(
                "createProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }),

                resolve: async context =>
                {
                    var p = context.GetArgument<Product>("product");
                    return await Task.FromResult(productRepository.Create(p));

                });




            /*
             *      mutation ($product: productInput!) {
                         createProduct(product: $product)
                    }

             */

            /*
             {
                  "product":{
                    "name": "from playground",
                    "categoryId" : 555,
                     "count" : 0,
                    "available":false
                  }
                }
             */
        }
    }
}
