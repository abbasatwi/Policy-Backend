using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey("PolicyId")]
        public Policy? Policy { get; set; }
        public int PolicyMemberId { get; set; }
        public DateTime ClaimDate { get; set; }
        public float ClaimAmount { get; set; }
        [ForeignKey("PolicyMemberId")]
        public PolicyMember? PolicyMember { get; set; }
    }
}
