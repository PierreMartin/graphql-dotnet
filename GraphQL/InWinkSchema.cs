using System;
using GraphQL.Types;
using GraphQL.Utilities;
using InfiniteSquare_InWink_GraphQl.Queries;

namespace InfiniteSquare_InWink_GraphQl
{
    public class InWinkSchema : Schema
    {
        public InWinkSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<InWinkQuery>();
            // Mutation = provider.GetRequiredService<InWinkMutation>(); // TODO finish it
        }
    }
}
