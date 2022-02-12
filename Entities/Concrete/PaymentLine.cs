using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class PaymentLine:Entity
    {
        [Key]
        public int PaymentLineId { get; set; }
        public int PaymentId { get; set; }
        public int PartNo { get; set; }
        public double Amount { get; set; }
        public char IsPaid { get; set; }
    }
}