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
        public async Task CanGetCustomers()
        {
            var customers = await _apiClient.GetCustomers();

            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public async Task CanGetBets()
        {
            var bets = await _apiClient.GetBets();

            Assert.IsTrue(bets.Any());
        }

        [TestMethod]
        public async Task CanGetRaces()
        {
            var races = await _apiClient.GetRaces();

            Assert.IsTrue(races.Any());
        }
    }
}