using System.Net.Http.Headers;
using System.Net.Http.Json;
using Flurl;

namespace ParatranzAPI
{
    public partial class ParatranzClient : IDisposable
    {
        readonly HttpClient m_Client;

        public ParatranzClient(string apiToken)
        {
            m_Client = new HttpClient();
            m_Client.BaseAddress = new Uri("https://paratranz.cn/api/");
            m_Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiToken);
        }

        public void Dispose()
        {
            m_Client.Dispose();
        }
    }
}