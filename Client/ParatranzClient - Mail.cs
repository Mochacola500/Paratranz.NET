using Flurl;

namespace Paratranz.NET
{
    public partial class ParatranzClient //NOSONAR
    {
        public Task<ParatranzPage<ParatranzMail>?> GetMailPageAsync(int page = 1, int pageSize = 50, CancellationToken token = default)
        {
            var query = new
            {
                page,
                pageSize
            };
            var url = "mails".SetQueryParams(query);

            return GetAsync<ParatranzPage<ParatranzMail>>(url, token);
        }

        public Task<ParatranzMail[]?> GetMailsAsync(int userId, CancellationToken token = default)
        {
            var url = "mails".AppendPathSegments("conversations", userId);

            return GetAsync<ParatranzMail[]>(url, token);
        }
    }
}