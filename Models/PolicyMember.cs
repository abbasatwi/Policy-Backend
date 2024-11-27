using System.Security.Claims;

namespace API.Models
{
    public class PolicyMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Policy>? Policies { get; set; }

        public List<Claim>? Claims { get; set; }

    }
}
