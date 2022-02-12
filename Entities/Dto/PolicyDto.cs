using System;

namespace Entities.Dto
{
    public class PolicyDto:Dto
    {
        public string PolicyNo { get; set; }
        public int InsurerId { get; set; }
        public int InsuredId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreateDate { get; set; }
        public double Amount { get; set; }
        public char IsPaid { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Relation { get; set; }
    }
}