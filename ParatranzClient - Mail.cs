using System.Net.Http.Headers;
using System.Net.Http.Json;
using Flurl;
using System.Text.Json.Nodes;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzMailBox?> GetMailBoxAsync(int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var url = "mails/".SetQueryParams(new { page = page, pageSize = pageSize });

            return m_Client.GetFromJsonAsync<ParatranzMailBox>(url, token);
        }

        public async Task<ParatranzMailBox.Mail?> PostMailAsync(string content, int status, CancellationToken token = default)
        {
            var json = new JsonObject
            {
                ["content"] = content,
                ["status"] = status,
            };
            var response = await m_Client.PostAsJsonAsync("mails/", json, token);
            return await response.Content.ReadFromJsonAsync<ParatranzMailBox.Mail>(options: null, token);
        }

        public Task<ParatranzMailBox.Mail[]?> GetMailsAsync(int userId, CancellationToken token = default)
        {
            var url = "mails/".AppendPathSegments("conversations", userId);

            return m_Client.GetFromJsonAsync<ParatranzMailBox.Mail[]>(url, token);
        }
    }

    public class ParatranzMailBox
    {
        public class Mail
        {
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

        public int page { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public int pageCount { get; set; }
        public Mail[]? results { get; set; }
    }
}