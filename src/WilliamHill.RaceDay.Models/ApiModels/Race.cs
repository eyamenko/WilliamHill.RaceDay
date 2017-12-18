using System;
using System.Collections.Generic;

namespace WilliamHill.RaceDay.Models.ApiModels
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public RaceStatus Status { get; set; }
        public IList<Horse> Horses { get; set; }
    }
}