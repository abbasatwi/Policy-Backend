using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PolicyDto
    {
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
    }
}
