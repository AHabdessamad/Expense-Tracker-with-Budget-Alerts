
using System.ComponentModel.DataAnnotations;

namespace SharedDtos
{
    public record ExpenseDto
    (
        [Required]
        [MaxLength(50)]
         string Name,
         [Required]
         int CategoryId,
         [Required]
         double Balance
    );
}
