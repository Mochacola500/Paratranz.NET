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

        public Task<ParatranzUser?> UpdateUserAsync(int userId, string nickname, string bio, string avatar, CancellationToken token = default)
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

        public Task UpdateNickNameAsync(ParatranzUser user, string nickname, CancellationToken token = default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (user.Bio == null)
            {
                throw new ArgumentNullException(nameof(user.Bio));
            }
            if (user.Avatar == null)
            {
                throw new ArgumentNullException(nameof(user.Avatar));
            }
            return UpdateUserAsync(user.Id, nickname, user.Bio, user.Avatar.AbsoluteUri, token);
        }

        public Task UpdateBioAsync(ParatranzUser user, string bio, CancellationToken token = default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (user.NickName == null)
            {
                throw new ArgumentNullException(nameof(user.NickName));
            }
            if (user.Avatar == null)
            {
                throw new ArgumentNullException(nameof(user.Avatar));
            }
            return UpdateUserAsync(user.Id, user.NickName, bio, user.Avatar.AbsoluteUri, token);
        }
    }
}