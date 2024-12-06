using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ExpenseTrackerDataAccessLayer.Entities
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [JsonIgnore]
        public Category Category { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public User User { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
