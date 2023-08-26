using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unitagram.Core.Domain.Entities
{
    public class University
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Province can not be blank")]
        [StringLength(50, ErrorMessage = "Province should be maximum of 50 characters long")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "University name can not be blank")]
        [StringLength(100, ErrorMessage = "University name should be maximum of 100 characters long")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Domain can not be blank")]
        [StringLength(50, ErrorMessage = "Domain should be maximum of 50 characters long")]
        public string Domain { get; set; } = string.Empty;

        public DateTime? Inserted { get; set; }

        public DateTime? LastUpdated { get; set; }

        public bool IsActive { get; set; } = true;

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
