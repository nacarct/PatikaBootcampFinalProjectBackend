using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPolicyRepository
    {
        public List<PolicyView> GetAllPolicyView();
        public List<Policy> GetAllPolicy();
        public string AddPolicy(Policy policy);
    }
}