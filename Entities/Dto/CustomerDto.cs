using System;

namespace Entities.Dto
{
    public class CustomerDto:Dto
    {
        public int CustomerId { get; set; }
        public string CustomerTcKn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}