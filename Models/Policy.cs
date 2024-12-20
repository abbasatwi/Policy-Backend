﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Policy
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateOnly CreationDate { get; set; }
        [Required]
        public DateOnly EffectiveDate { get; set; }
        [Required]
        public DateOnly ExpiryDate { get; set; }
        [Required]
        public int PolicyTypeId { get; set; }
        [ForeignKey("PolicyTypeId")]
        public PolicyType? PolicyType { get; set; }
        public List<PolicyMember>? PolicyMembers { get; set; }

    }
}
