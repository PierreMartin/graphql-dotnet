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

            // User:
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => data.GetUsers()
            );

            Field<UserType>(
                "user",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the user" }
                ),
                resolve: context => data.GetUserByIdAsync(context.GetArgument<string>("id"))
            );

            // Post:
            Field<ListGraphType<PostType>>(
                "posts",
                resolve: context => data.GetPosts()
            );

            Field<PostType>(
                "post",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the post" }
                ),
                resolve: context => data.GetPostsByIdAsync(context.GetArgument<string>("id"))
            );
        }
    }
}
