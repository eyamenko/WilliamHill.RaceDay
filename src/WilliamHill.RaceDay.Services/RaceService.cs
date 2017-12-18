using System;
using System.Collections.Generic;
using System.Linq;
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
            var races = await _apiClient.GetRaces();
            var bets = await _apiClient.GetBets();

            return races.Select(r => new Race
            {
                Id = r.Id,
                Status = r.Status,
                TotalAmount = bets.Where(b => b.RaceId == r.Id).Sum(b => b.Stake),
                Horses = r.Horses.Select(h => new Horse
                {
                    Id = h.Id,
                    Name = h.Name,
                    TotalBets = bets.Count(b => b.RaceId == r.Id && b.HorseId == h.Id),
                    TotalPayout = bets.Where(b => b.RaceId == r.Id && b.HorseId == h.Id).Sum(b => b.Stake) * h.Odds
                }).ToList()
            }).ToList();
        }
    }
}