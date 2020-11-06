using GraphQL.Types;
using InfiniteSquare_InWink_GraphQl.Models;
using InfiniteSquare_InWink_GraphQl.FakeData;

namespace InfiniteSquare_InWink_GraphQl.Types
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType(InWinkData data)
        {
            Name = "Post";

            Field(h => h.Id).Description("The id of the post.");
            Field(h => h.Content, nullable: true).Description("The firstName of the post.");
        }
    }
}
