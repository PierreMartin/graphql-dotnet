Doc => https://graphql-dotnet.github.io/docs/getting-started/introduction
Example => https://github.com/graphql-dotnet/examples/tree/master/src/StarWars

## Add packages:
dotnet add package GraphQL
dotnet add package GraphQL.SystemTextJson // recommended for .NET Core 3+
dotnet add package GraphQL.Server.Transports.AspNetCore.SystemTextJson --version 4.2.1
dotnet add package GraphQL.NewtonsoftJson
dotnet add package GraphQL.Server.Ui.GraphiQL --version 4.2.1
dotnet add package GraphQL.Server.Ui.Playground --version 4.2.1
dotnet add package GraphQL.Server.Transports.AspNetCore --version 4.2.1
dotnet add package Newtonsoft.Json --version 12.0.3

GraphiQL Server     => `localhost:5001/graphql`
GraphQL Playground  => `localhost:5001/ui/playground`

For tests queries, go to graphiql localhost:5001/ui/playground

## ALL
```
query {
    users {
        FirstName,
        LastName,
        Id
    }
}
```

## ONE
```
query {
  user(id: "1") {
        FirstName,
        LastName,
        Id
  }
}
```

## SET
```
mutation {
  addUser(FirstName: "toto" ) {
    FirstName
  }
}
```
