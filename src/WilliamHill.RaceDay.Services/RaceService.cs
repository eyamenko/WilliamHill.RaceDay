using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WilliamHill.RaceDay.Contracts.ApiClients;
using WilliamHill.RaceDay.Contracts.Services;
using WilliamHill.RaceDay.Models.ViewModels;

namespace WilliamHill.RaceDay.Services
{
    public class RaceService : IRaceService
    {
        private readonly IWhatechApiClient _apiClient;

        public RaceService(IWhatechApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IList<Race>> GetRaces()
        {
            throw new NotImplementedException();
        }
    }
}