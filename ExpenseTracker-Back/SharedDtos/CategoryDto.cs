using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDtos
{
    public record CategoryDto
    (
        [Required]
        string Type,
        [Required]
        [MaxLength(200)]
        string Note
    );
}
