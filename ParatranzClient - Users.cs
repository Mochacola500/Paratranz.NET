using Flurl;
using System.Text.Json.Nodes;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        public Task<ParatranzUser?> GetUserAsync(int userId, CancellationToken token = default)
        {
            var url = "users".AppendPathSegments(userId);

            return GetAsync<ParatranzUser>(url, token);
        }

        public Task<ParatranzUser?> ChangeUserInfoAsync(int userId, string nickname, string bio, string avatar, CancellationToken token = default)
        {
            var url = "users".AppendPathSegments(userId);
            var json = new JsonObject
            {
                ["nickname"] = nickname,
                ["bio"] = bio,
                ["avatar"] = avatar,
            };
            
            return PutAsync<JsonObject, ParatranzUser>(url, json, token);
        }
    }

    public class ParatranzUser
    {
        public int id { get; set; }
        public string? createdAt { get; set; }
        public string? updateAt { get; set; }
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
}