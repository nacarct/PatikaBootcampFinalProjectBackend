namespace Entities.Dto
{
    public class PaymentDto:Dto
    {
        public int PolicyId { get; set; }
        public char IsAllPaid { get; set; }
        public int PaymentPart { get; set; }
        public double PaymentAmount { get; set; }
    }
}