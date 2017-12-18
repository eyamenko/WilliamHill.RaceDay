namespace WilliamHill.RaceDay.Models.ViewModels
{
    public class Customer
    {
        public int Id { get; set; }
        public int TotalBets { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsRisky { get; set; }
    }
}