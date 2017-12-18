using System.Threading.Tasks;
using WilliamHill.RaceDay.Models.ViewModels;

namespace WilliamHill.RaceDay.Contracts.Services
{
    public interface ICustomerService
    {
        Task<CustomerList> GetCustomers();
    }
}