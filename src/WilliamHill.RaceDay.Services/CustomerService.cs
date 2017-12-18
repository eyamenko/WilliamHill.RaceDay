using System.Linq;
using System.Threading.Tasks;
using WilliamHill.RaceDay.Contracts.ApiClients;
using WilliamHill.RaceDay.Contracts.Services;
using WilliamHill.RaceDay.Models.ViewModels;

namespace WilliamHill.RaceDay.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IWhatechApiClient _apiClient;
        private readonly decimal _riskThreshold;

        public CustomerService(IWhatechApiClient apiClient, decimal riskThreshold)
        {
            _apiClient = apiClient;
            _riskThreshold = riskThreshold;
        }

        public async Task<CustomerList> GetCustomers()
        {
            var customers = await _apiClient.GetCustomers();
            var bets = await _apiClient.GetBets();

            return new CustomerList
            {
                TotalAmountBet = bets.Sum(b => b.Stake),
                Customers = customers.Select(c =>
                {
                    var customerBets = bets.Where(b => b.CustomerId == c.Id).ToList();

                    return new Customer
                    {
                        Id = c.Id,
                        TotalBets = customerBets.Count,
                        TotalAmountBet = customerBets.Sum(b => b.Stake),
                        IsRisky = customerBets.Any(b => b.Stake > _riskThreshold)
                    };
                }).ToList()
            };
        }
    }
}