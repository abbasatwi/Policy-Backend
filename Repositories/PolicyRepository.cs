using API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ApplicationDbContext _context;

        public PolicyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> GetTotalPoliciesCountAsync()
        {
            return await _context.Policies.CountAsync();
        }

        public async Task<Policy> CreatePolicyAsync(Policy policy)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.Policies.Add(policy);
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();
                return policy;
            }
            catch
            {
                // Rollback the transaction in case of error
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeletePolicyAsync(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var policy = await _context.Policies.FindAsync(id);
                if (policy == null)
                {
                    await transaction.RollbackAsync();
                    return false;
                }

                _context.Policies.Remove(policy);
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                // Rollback the transaction in case of error
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<Policy>> GetAllPoliciesAsync(int pageNumber, int pageSize)
        {
            return await _context.Policies
                .Include(p => p.PolicyType)
                .Include(p => p.PolicyMembers)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Policy?> GetPolicyByIdAsync(int id)
        {
            return await _context.Policies
                .Include(p => p.PolicyType)
                .Include(p => p.PolicyMembers)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Policy?> UpdatePolicyAsync(Policy policy)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var existingPolicy = await _context.Policies.FindAsync(policy.Id);
                if (existingPolicy == null)
                {
                    await transaction.RollbackAsync();
                    return null;
                }

                _context.Entry(existingPolicy).CurrentValues.SetValues(policy);
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();
                return existingPolicy;
            }
            catch
            {
                // Rollback the transaction in case of error
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
