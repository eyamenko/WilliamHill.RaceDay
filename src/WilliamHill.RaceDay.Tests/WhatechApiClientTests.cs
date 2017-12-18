using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.RaceDay.ApiClients;
using WilliamHill.RaceDay.Contracts.ApiClients;

namespace WilliamHill.RaceDay.Tests
{
    [TestClass]
    public class WhatechApiClientTests
    {
        private readonly IWhatechApiClient _apiClient;

        public WhatechApiClientTests()
        {
            _apiClient = new WhatechApiClient("https://whatech-customerbets.azurewebsites.net", "eugene");
        }

        [TestMethod]
        public async Task TestGetCustomers()
        {
            var customers = await _apiClient.GetCustomers();

            Assert.IsTrue(customers.Any());
        }
    }
}