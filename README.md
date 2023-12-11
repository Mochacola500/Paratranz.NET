[OpenAPILink]: https://paratranz.cn/docs

# Paratranz.NET
A client library for Paratranz API 

# OpenAPI
**Document:** [ParaTranz OpenAPI][OpenAPILink]

# Usage

Create a client

```cs
string apiToken = "your API Token";
using var client = new ParatranzClient(apiToken);
```

Get user

```cs
int userId = 0000;
var user = await client.GetUserAsync(userId);
Console.WriteLine(user.UserName);
```

