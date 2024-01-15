using Flurl;
using System.Text.Json.Nodes;

namespace Paratranz.NET
{
    public partial class ParatranzClient //NOSONAR
    {
        public Task<ParatranzUser?> GetUserAsync(int userId, CancellationToken token)
        {
            var url = "users".AppendPathSegments(userId);

            return GetAsync<ParatranzUser>(url, token);
        }

        public Task<ParatranzUser?> UpdateUserAsync(int userId, string nickname, string bio, string avatar, CancellationToken token)
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
}