namespace SalesWebSystem.Models.Models.DTO.BusinessDTO
{
    public class BalanceDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int BusinessId { get; set; }
    }
}
