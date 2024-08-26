using System.Text;

namespace Paratranz.NET
{
    public partial class ParatranzService : IDisposable
    {
        readonly ParatranzClient Client;
        bool Disposed;

        public ParatranzService(string apiToken)
            : this(new ParatranzClient(apiToken))
        {
            
        }

        public ParatranzService(string apiToken, HttpClientHandler clientHandler)
            : this(new ParatranzClient(apiToken, clientHandler))
        {

        }

        public ParatranzService(string apiToken, HttpClientHandler clientHandler, bool disposeHandler)
            : this(new ParatranzClient(apiToken, clientHandler, disposeHandler))
        {
            
        }

        public ParatranzService(ParatranzClient client)
        {
            Client = client;
        }

        #region IDisposable Implement

        ~ParatranzService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !Disposed)
            {
                Disposed = true;
                Client.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion // IDisposable Implement

        #region Helper Implement

        public static string ToQueryParams(params object[] queryParams)
        {
            if (queryParams.Length % 2 != 0)
            {
                throw new ArgumentException("Query parameters must be in key-value pairs.");
            }

            var queryString = new StringBuilder("?");
            for (int i = 0; i < queryParams.Length; i += 2)
            {
                if (i > 0)
                {
                    queryString.Append("&");
                }

                string key = Uri.EscapeDataString(queryParams[i].ToString() ?? string.Empty);
                string value = Uri.EscapeDataString(queryParams[i + 1].ToString() ?? string.Empty);
                queryString.Append($"{key}={value}");
            }

            return queryString.ToString();
        }

        #endregion // Helper Implements
    }
}