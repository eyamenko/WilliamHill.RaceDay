using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WilliamHill.RaceDay.Contracts.ApiClients;
using WilliamHill.RaceDay.Contracts.Services;
using WilliamHill.RaceDay.Models.ApiModels;
using WilliamHill.RaceDay.Services;

namespace WilliamHill.RaceDay.Tests
{
    [TestClass]
    public class RaceServiceTests
    {
        private readonly IRaceService _raceService;

        public RaceServiceTests()
        {
            var apiClientMock = new Mock<IWhatechApiClient>();

            apiClientMock.Setup(c => c.GetRaces()).Returns(() =>
            {
                IList<Race> races = new List<Race>
                {
                    new Race
                    {
                        Id = 1,
                        Name = "Race 1",
                        Start = DateTime.UtcNow,
                        Status = RaceStatus.InProgress,
                        Horses = new List<Horse>
                        {
                            new Horse
                            {
                                Id = 1,
                                Name = "Horse 1",
                                Odds = 5.5m
                            }
                        }
                    }
                };

                return Task.FromResult(races);
            });

            apiClientMock.Setup(c => c.GetBets()).Returns(() =>
            {
                IList<Bet> bets = new List<Bet>
                {
                    new Bet
                    {
                        CustomerId = 1,
                        HorseId = 1,
                        RaceId = 1,
                        Stake = 13.37m
                    },
                    new Bet
                    {
                        CustomerId = 2,
                        HorseId = 1,
                        RaceId = 1,
                        Stake = 19.91m
                    }
                };

                return Task.FromResult(bets);
            });

            _raceService = new RaceService(apiClientMock.Object);
        }

        [TestMethod]
        public async Task CanGetRaceStatus()
        {
            var races = await _raceService.GetRaces();
            var race = races.First();

            Assert.AreEqual(RaceStatus.InProgress, race.Status);
        }

        [TestMethod]
        public async Task CanGetTotalAmountPlaced()
        {
            var races = await _raceService.GetRaces();
            var race = races.First();

            Assert.AreEqual(33.28m, race.TotalAmount);
        }

        [TestMethod]
        public async Task CanListHorses()
        {
            var races = await _raceService.GetRaces();
            var race = races.First();

            Assert.AreEqual(1, race.Horses.Count);
        }

        [TestMethod]
        public async Task CanGetNumberOfBetsPlacedOnHorse()
        {
            var races = await _raceService.GetRaces();
            var race = races.First();
            var horse = race.Horses.First();

            Assert.AreEqual(2, horse.TotalBets);
        }

        [TestMethod]
        public async Task CanGetTotalPayoutPerHorse()
        {
            var races = await _raceService.GetRaces();
            var race = races.First();
            var horse = race.Horses.First();

            Assert.AreEqual(183.04m, horse.TotalPayout);
        }
    }
}