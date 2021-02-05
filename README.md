- Doc => https://graphql-dotnet.github.io/docs/getting-started/introduction
- Example => https://github.com/graphql-dotnet/examples/tree/master/src/StarWars

## Add packages:
- dotnet add package GraphQL
- dotnet add package GraphQL.SystemTextJson // recommended for .NET Core 3+
- dotnet add package GraphQL.Server.Transports.AspNetCore.SystemTextJson --version 4.2.1
- dotnet add package GraphQL.NewtonsoftJson
- dotnet add package GraphQL.Server.Ui.GraphiQL --version 4.2.1
- dotnet add package GraphQL.Server.Ui.Playground --version 4.2.1
- dotnet add package GraphQL.Server.Transports.AspNetCore --version 4.2.1
- dotnet add package Newtonsoft.Json --version 12.0.3

GraphiQL Server at `localhost:5001/ui/playground`

## GET ALL
```
query {
    users {
        firstName,
        lastName,
        id
    }
}
```

## GET ONE
```
query {
  user(id: "1") {
        firstName,
        lastName,
        id
  }
}
```

## ADD / UPDATE
```
mutation {
  addUser(FirstName: "toto" ) {
    firstName
  }
}
```
