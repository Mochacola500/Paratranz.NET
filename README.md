# Paratranz.NET

A client library for Paratranz API 

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/4e556876a3c54d5e8f2d2857c4f43894)][codacy]&nbsp;
[![GitHub license](https://img.shields.io/github/license/cotes2020/jekyll-theme-chirpy.svg)][license]&nbsp;

## OpenAPI
**Document:** [ParaTranz OpenAPI][OpenAPILink]

## Requirement
`Flurl`

## Usage

### Client

```cs
using var client = new ParatranzClient(apiToken);
```

### User

```cs
var user = await client.GetUserAsync(userId);
Console.WriteLine(user.UserName);
```

### String

```cs
var str = await client.GetStringAsync(projectId, stringId);
Console.WriteLine(str.Translation);

var request = str.CreateRequest(fileId);
request.Translation = "new text";

var result = await client.UpdateStringAsync(projectId, stringId, request);
Console.WriteLine(result.Translation);

await client.DeleteStringAsync(projectId, stringId);
```

### Project

```cs
var project = await client.CreateProjectAsync(projectId):
await client.DeleteProjectAsync(projectId);
```

### History

```cs
var userHistory = await client.GetUserHistoryAsync(projectId, TranslateHistoryType.text, uid, tid);
var fileHistory = await client.GeFiletHistoryAsync(projectId, fileId, FileHistoryType.create);
```

### Artifact

```cs
var buildInfo = await client.BuildArtifactAsync(projectId);
Stream downloadStream = await client.DownloadArtifactAsync(projectId);

using (var fs = File.Open(savePath))
{
    downloadStream.CopyTo(fs);
}
```

### Mail

```cs
var mails = await client.GetMailsAsync(userId);

foreach (var mail in mails)
{
    Console.WriteLine($"User:{mail.FromUser.UserName}");
    Console.WriteLine($"Content:{mail.Content}");
}
```

### Issue

```cs
var issues = await client.GetissuePageAsync(projectId, IssuesStatus.Discussion);

foreach (var issue in issues.Results)
{
    Console.WriteLine(issue.Title);
}
```

### Score

```cs
var scores = await client.GetScorePageAsync(projectId, uid, OperationType.Translate, start, end);

foreach (var score in scores.Results)
{
    Console.WriteLine($"User: {score.User.UserName}");
    Console.WriteLine($"Point: {score.Value}"):
}
```

[OpenAPILink]: https://paratranz.cn/docs
[codacy]: https://app.codacy.com/gh/Mochacola500/Paratranz.NET/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade
[license]: https://github.com/Mochacola500/Paratranz.NET/blob/master/LICENSE
