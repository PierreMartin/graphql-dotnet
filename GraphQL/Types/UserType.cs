using GraphQL.Types;
using InfiniteSquare_InWink_GraphQl.Models;
using InfiniteSquare_InWink_GraphQl.FakeData;

namespace InfiniteSquare_InWink_GraphQl.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(InWinkData data)
        {
            Name = "User";

            // Field(h => h.Id); No description
            Field(h => h.Id).Description("The id of the user.");
            Field(h => h.FirstName, nullable: true).Description("The firstName of the user.");
            Field(h => h.LastName, nullable: true).Description("The lastName of the user.");
        }
    }
}
