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
    public class CustomerServiceTests
    {
        private readonly ICustomerService _customerService;

        public CustomerServiceTests()
        {
            var apiClientMock = new Mock<IWhatechApiClient>();

            apiClientMock.Setup(c => c.GetCustomers()).Returns(() =>
            {
                IList<Customer> customers = new List<Customer>
                {
                    new Customer
                    {
                        Id = 1,
                        Name = "John Doe"
                    },
                    new Customer
                    {
                        Id = 2,
                        Name = "Jane Doe"
                    },
                };

                return Task.FromResult(customers);
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
                        CustomerId = 1,
                        HorseId = 2,
                        RaceId = 2,
                        Stake = 201.0m
                    },
                    new Bet
                    {
                        CustomerId = 2,
                        HorseId = 3,
                        RaceId = 3,
                        Stake = 120m
                    },
                    new Bet
                    {
                        CustomerId = 2,
                        HorseId = 4,
                        RaceId = 4,
                        Stake = 120m
                    }
                };

                return Task.FromResult(bets);
            });

            _customerService = new CustomerService(apiClientMock.Object, 200);
        }

        [TestMethod]
        public async Task CanListCustomers()
        {
            var customerList = await _customerService.GetCustomers();
            var customers = customerList.Customers;

            Assert.AreEqual(2, customers.Count);
        }

        [TestMethod]
        public async Task CanGetTotalBetsPlacedPerCustomer()
        {
            var customerList = await _customerService.GetCustomers();
            var customers = customerList.Customers;
            var customer = customers.First();

            Assert.AreEqual(2, customer.TotalBets);
        }

        [TestMethod]
        public async Task CanGetTotalAmountBetPerCustomer()
        {
            var customerList = await _customerService.GetCustomers();
            var customers = customerList.Customers;
            var customer = customers.First();

            Assert.AreEqual(214.37m, customer.TotalAmountBet);
        }

        [TestMethod]
        public async Task CanGetTotalAmountBetForAllCustomers()
        {
            var customerList = await _customerService.GetCustomers();

            Assert.AreEqual(454.37m, customerList.TotalAmountBet);
        }

        [TestMethod]
        public async Task CanDetermineRiskyCustomer()
        {
            var customerList = await _customerService.GetCustomers();
            var customers = customerList.Customers;
            var customer = customers.First();

            Assert.IsTrue(customer.IsRisky);
        }

        [TestMethod]
        public async Task CanDetermineNonRiskyCustomer()
        {
            var customerList = await _customerService.GetCustomers();
            var customers = customerList.Customers;
            var customer = customers.Last();

            Assert.IsFalse(customer.IsRisky);
        }
    }
}