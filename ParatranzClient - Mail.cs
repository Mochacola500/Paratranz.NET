using Flurl;
using System.Text.Json.Nodes;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzMail?> GetMailAsync(string content, int status, CancellationToken token = default)
        {
            var url = "mails";
            var json = new JsonObject
            {
                ["content"] = content,
                ["status"] = status,
            };
            return PostAsync<JsonObject, ParatranzMail>(url, json, token);
        }

        public Task<ParatranzMail[]?> GetMailsAsync(int userId, CancellationToken token = default)
        {
            var url = "mails".AppendPathSegments("conversations", userId);

            return GetAsync<ParatranzMail[]>(url, token);
        }

        public Task<ParatranzMailPage?> GetMailPageAsync(int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var query = new
            {
                page = page,
                pageSize = pageSize
            };
            var url = "mails".SetQueryParams(query);

            return GetAsync<ParatranzMailPage>(url, token);
        }
    }

    public class ParatranzMailPage
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public int pageCount { get; set; }
        public ParatranzMail[]? results { get; set; }
    }

    public class ParatranzMail
    {
        public class Content
        {
            public int id { get; set; }
            public string? createdAt { get; set; }
            public string? updatedAt { get; set; }
            public string? lastVisit { get; set; }
            public string? username { get; set; }
            public string? nickname { get; set; }
            public string? bio { get; set; }
            public string? avatar { get; set; }
            public string? email { get; set; }
            public int credit { get; set; }
            public int translated { get; set; }
            public int edited { get; set; }
            public int reviewed { get; set; }
            public int commented { get; set; }
            public int points { get; set; }
        }

        public int id { get; set; }
        public string? createdAt { get; set; }
        public int from { get; set; }
        public Content? fromUser { get; set; }
        public int to { get; set; }
        public Content? toUser { get; set; }
        public string? content { get; set; }
        public string? html { get; set; }
        public int status { get; set; }
    }
}