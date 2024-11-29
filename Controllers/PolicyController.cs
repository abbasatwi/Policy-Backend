using API.Dtos;
using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
public class PolicyController : ControllerBase
{
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

    [HttpGet]
    public async Task<IActionResult> GetAllPolicies([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var policies = await _policyService.GetAllPoliciesAsync(pageNumber, pageSize);
        return Ok(policies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPolicyById(int id)
    {
        try
        {
            var policy = await _policyService.GetPolicyByIdAsync(id);
            if (policy == null)
                return NotFound(new { message = $"Policy with ID {id} not found." });
            return Ok(policy);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving the policy.", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePolicy([FromBody] CreatePolicyDto policy)
    {
        try
        {

            var createdPolicy = await _policyService.CreatePolicyAsync(policy);
            return CreatedAtAction(nameof(GetPolicyById), new { id = createdPolicy.Id }, createdPolicy);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while creating the policy.", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePolicy(int id, [FromBody] PolicyDto policy)
    {
        try
        {
            var updatedPolicy = await _policyService.UpdatePolicyAsync(policy,id);
            if (updatedPolicy == null)
                return NotFound(new { message = $"Policy with ID {id} not found." });
            return Ok(updatedPolicy);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while updating the policy.", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePolicy(int id)
    {
        try
        {
            var deleted = await _policyService.DeletePolicyAsync(id);
            if (!deleted) return NotFound(new { message = $"Policy with ID {id} not found." });
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while deleting the policy.", error = ex.Message });
        }
    }

}
