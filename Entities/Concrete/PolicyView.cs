using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Entities.Concrete
{
    public class PolicyView
    {
        [Key]
        public int PolicyId { get; set; }
        public string PolicyNo { get; set; }
        public int InsurerId { get; set; }
        public string InsrTcKn { get; set; }
        public string InsrFirstName { get; set; }
        public string InsrLastName { get; set; }
        public DateTime InsrBirthDate { get; set; }
        public string InsrGender { get; set; }
        public string InsrPhone { get; set; }
        public string InsrAddress { get; set; }
        public int InsuredId { get; set; }
        public string CustomerTcKn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Relation { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Amount { get; set; }
        public char IsPaid { get; set; }
        public char IsAllPaid { get; set; }
        public int PaymentPart { get; set; }
        
        public double PaymentAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public int PaidPart { get; set; }
    }
}