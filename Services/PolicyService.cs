using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Services;

public class PolicyService : IPolicyService
{
    private readonly IPolicyRepository _policyRepository;

    public PolicyService(IPolicyRepository policyRepository)
    {
        _policyRepository = policyRepository;
    }

    public async Task<IEnumerable<Policy>> GetAllPoliciesAsync(int pageNumber, int pageSize)
    {
        return await _policyRepository.GetAllPoliciesAsync(pageNumber, pageSize);
    }

    public async Task<Policy?> GetPolicyByIdAsync(int id)
    {
        return await _policyRepository.GetPolicyByIdAsync(id);
    }

    public async Task<Policy> CreatePolicyAsync(PolicyDto policyDto)
    {
        
        if (policyDto.EffectiveDate < policyDto.CreationDate)
        {
            throw new ArgumentException("Effective date cannot be earlier than the creation date.");
        }

        if (policyDto.ExpiryDate <= policyDto.EffectiveDate)
        {
            throw new ArgumentException("Expiry date must be after the effective date.");
        }

        // Convert PolicyDto to Policy (model)
        var policy = new Policy
        {
            Name = policyDto.Name,
            Description = policyDto.Description,
            CreationDate = policyDto.CreationDate,
            EffectiveDate = policyDto.EffectiveDate,
            ExpiryDate = policyDto.ExpiryDate,
            PolicyTypeId = policyDto.PolicyTypeId
        };

        // Pass the model to the repository to create the policy
        return await _policyRepository.CreatePolicyAsync(policy);
    }

    public async Task<Policy?> UpdatePolicyAsync(PolicyDto policyDto, int id)
    {
        // Example validation
        var existingPolicy = await _policyRepository.GetPolicyByIdAsync(id);
        if (existingPolicy == null)
        {
            return null; // Policy not found
        }

        if (policyDto.EffectiveDate < policyDto.CreationDate)
        {
            throw new ArgumentException("Effective date cannot be earlier than the creation date.");
        }

        if (policyDto.ExpiryDate <= policyDto.EffectiveDate)
        {
            throw new ArgumentException("Expiry date must be after the effective date.");
        }

        // Convert PolicyDto to Policy (model)
        var updatedPolicy = new Policy
        {
            Id = id,
            Name = policyDto.Name,
            Description = policyDto.Description,
            CreationDate = policyDto.CreationDate,
            EffectiveDate = policyDto.EffectiveDate,
            ExpiryDate = policyDto.ExpiryDate,
            PolicyTypeId = policyDto.PolicyTypeId
        };

        // Pass the updated model to the repository to update the policy
        return await _policyRepository.UpdatePolicyAsync(updatedPolicy);
    }


    public async Task<bool> DeletePolicyAsync(int id)
    {
        // You could add more logic here if required
        return await _policyRepository.DeletePolicyAsync(id);
    }
}
