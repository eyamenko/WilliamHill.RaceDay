namespace WilliamHill.RaceDay.Models
{
    public class Bet
    {
        public int CustomerId { get; set; }
        public int RaceId { get; set; }
        public int HorseId { get; set; }
        public double Stake { get; set; }
    }
}