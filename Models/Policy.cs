using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly EffectiveDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public int PolicyTypeId { get; set; }
        [ForeignKey("PolicyTypeId")]
        public PolicyType? PolicyType { get; set; }
        public List<PolicyMember> PolicyMembers { get; set; }

    }
}
