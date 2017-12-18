using System;
using System.Threading.Tasks;
using WilliamHill.RaceDay.Contracts.ApiClients;
using WilliamHill.RaceDay.Contracts.Services;
using WilliamHill.RaceDay.Models.ViewModels;

namespace WilliamHill.RaceDay.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IWhatechApiClient _apiClient;

        public CustomerService(IWhatechApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<CustomerList> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}