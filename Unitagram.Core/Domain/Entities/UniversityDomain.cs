using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Unitagram.Core.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class UniversityDomain
    {
        [Key]
        public int DomainId { get; set; }

        [Required(ErrorMessage = "Domain name can not be blank")]
        [StringLength(50, ErrorMessage = "Domain name should be maximum of 50 characters long")]
        public string Name { get; set; } = string.Empty;

        public int UniversityId { get; set; }
        public University University { get; set; }

    }
}
