using API.Dtos;
using API.Models;

namespace API.Services
{
    public interface IPolicyService
    {
        Task<IEnumerable<Policy>> GetAllPoliciesAsync(int pageNumber, int pageSize);
        Task<Policy?> GetPolicyByIdAsync(int id);
        Task<Policy> CreatePolicyAsync(PolicyDto policy);
        Task<Policy?> UpdatePolicyAsync(PolicyDto policy, int id);
        Task<bool> DeletePolicyAsync(int id);
        Task<int> GetTotalPoliciesCountAsync();
    }

}
