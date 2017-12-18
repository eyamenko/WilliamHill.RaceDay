using System.Collections.Generic;

namespace WilliamHill.RaceDay.Models.ViewModels
{
    public class CustomerList
    {
        public IList<Customer> Customers { get; set; }
        public decimal TotalAmountBet { get; set; }
    }
}