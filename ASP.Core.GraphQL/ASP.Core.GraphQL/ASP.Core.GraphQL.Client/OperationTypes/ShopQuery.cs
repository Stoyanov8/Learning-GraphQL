using ASP.Core.GraphQL.Client.Types;
using ASP.Core.GraphQL.Services.Repositories;
using GraphQL.Types;

namespace ASP.Core.GraphQL.Client.OperationTypes
{
    public class ShopQuery : ObjectGraphType
    {
        public ShopQuery(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetAll());


            Field<ListGraphType<ProductType>>(
                "productsByCategory",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "categoryId" }),
                resolve: context => productRepository.GetAllByCategory(context.GetArgument<int>("categoryId")));


            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return productRepository.GetById(id);
                });

            Field<ListGraphType<CategoryType>>(
                "categories",
                resolve: context => categoryRepository.GetAll());

            Field<CategoryType>("category",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return categoryRepository.GetById(id);
                });
        }
    }
}
