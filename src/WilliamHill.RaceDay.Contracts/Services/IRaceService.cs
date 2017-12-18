using System.Collections.Generic;
using System.Threading.Tasks;
using WilliamHill.RaceDay.Models.ViewModels;

namespace WilliamHill.RaceDay.Contracts.Services
{
    public interface IRaceService
    {
        Task<IList<Race>> GetRaces();
    }
}