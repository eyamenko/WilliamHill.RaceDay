using System.Collections.Generic;
using WilliamHill.RaceDay.Models.ApiModels;

namespace WilliamHill.RaceDay.Models.ViewModels
{
    public class Race
    {
        public int Id { get; set; }
        public RaceStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<Horse> Horses { get; set; }
    }
}