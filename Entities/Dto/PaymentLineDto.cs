namespace Entities.Dto
{
    public class PaymentLineDto:Dto
    {
        public int PaymentId { get; set; }
        public int PartNo { get; set; }
        public double Amount { get; set; }
        public char IsPaid { get; set; }
    }
}