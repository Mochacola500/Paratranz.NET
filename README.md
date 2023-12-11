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

User

```cs
var user = await client.GetUserAsync(userId);
Console.WriteLine(user.UserName);
```

String

```cs
var str = await client.GetStringAsync(projectId, stringId);
Console.WriteLine(str.Translation);

var request = new ParatranzStringRequest();
request.Key = str.Key;
request.Original = str.Original;
request.Translation = "new text";

var result = await client.UpdateStringAsync(projectId, stringId, request);
Console.WriteLine(result.Translation);

await client.DeleteStringAsync(projectId, stringId);
```

Artifact

```cs
var buildInfo = await client.BuildArtifactAsync(projectId);
Stream downloadStream = await client.DownloadArtifactAsync(projectId);

using (var fs = File.Open(download path...))
{
  downloadStream.CopyTo(fs);
}
```

Mail

```cs
var mails = await client.GetMailsAsync(userId);
```

Issue

```cs
var issues = await client.GetissuePageAsync(projectId, IssuesStatus.Discussion);

foreach (var issue in issues.Results)
{
  Console.WriteLine(issue.Title);
}
```

and More...
