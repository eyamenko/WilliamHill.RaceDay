using System.Collections.Generic;
using System.Threading.Tasks;
using WilliamHill.RaceDay.Models.ApiModels;

namespace WilliamHill.RaceDay.Contracts.ApiClients
{
    public interface IWhatechApiClient
    {
        Task<IList<Customer>> GetCustomers();
        Task<IList<Bet>> GetBets();
        Task<IList<Race>> GetRaces();
    }
}