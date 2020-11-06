using System;
using GraphQL;
using GraphQL.Types;
using InfiniteSquare_InWink_GraphQl.FakeData;
using InfiniteSquare_InWink_GraphQl.Types;

namespace InfiniteSquare_InWink_GraphQl.Queries
{
    public class InWinkQuery : ObjectGraphType<object>
    {
        public InWinkQuery(InWinkData data)
        {
            Name = "Query";

            Field<UserType>(
                "user",
                resolve: context => data.GetUsers()
            );

            Field<UserType>(
                "user",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the human" }
                ),
                resolve: context => data.GetUserByIdAsync(context.GetArgument<string>("id"))
            );
        }
    }
}
