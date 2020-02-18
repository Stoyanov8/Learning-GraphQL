using GraphQL.Types;

namespace ASP.Core.GraphQL.Client.Types
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "productInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<BooleanGraphType>("available");
            Field<IntGraphType>("count");
            Field<IntGraphType>("categoryId");
        }
    }
}
