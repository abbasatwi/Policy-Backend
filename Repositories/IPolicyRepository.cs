using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

public interface IPolicyRepository
{
    Task<IEnumerable<Policy>> GetAllPoliciesAsync(int pageNumber, int pageSize);
    Task<Policy?> GetPolicyByIdAsync(int id);
    Task<Policy> CreatePolicyAsync(Policy policy);
    Task<Policy?> UpdatePolicyAsync(Policy policy);
    Task<bool> DeletePolicyAsync(int id);
}
