
namespace Paratranz.NET.Test
{
    [TestFixture]
    public class ParatranzClientTest
    {
        [Test]
        public void AuthorizationTest()
        {
            var apiToken = Environment.GetEnvironmentVariable("API_TOKEN");
            Assert.IsNotNull(apiToken, "API_TOKEN: {0}", apiToken);

            try
            {
                new ParatranzClient(apiToken);
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}