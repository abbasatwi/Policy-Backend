using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace API
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyMember> PolicyMembers { get; set; }
        public DbSet<MemberClaim> MemberClaims { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }
    }
}
