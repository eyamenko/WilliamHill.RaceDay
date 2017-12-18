namespace WilliamHill.RaceDay.Models.ApiModels
{
    public class Bet
    {
        public int CustomerId { get; set; }
        public int RaceId { get; set; }
        public int HorseId { get; set; }
        public decimal Stake { get; set; }
    }
}