using ASP.Core.GraphQL.Client.OperationTypes;
using GraphQL;
using GraphQL.Types;

namespace ASP.Core.GraphQL.Client.Schemas
{
    public class ShopSchema : Schema
    {
        public ShopSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ShopQuery>();
            Mutation = resolver.Resolve<ShopMutation>();
        }
    }
}
