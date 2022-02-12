using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Payment:Entity
    {
        [Key]
        public int PaymentId { get; set; }
        public int PolicyId { get; set; }
        public char IsAllPaid { get; set; }
        public int PaymentPart { get; set; }
        public double PaymentAmount { get; set; }
    }
}