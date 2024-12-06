using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDtos
{
    public record BodgetDto
    (
        [Required]
        double balance
    );
}
