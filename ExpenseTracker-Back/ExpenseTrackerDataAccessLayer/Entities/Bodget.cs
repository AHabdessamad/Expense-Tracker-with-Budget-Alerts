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
    public class Bodget
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Double Balance {  get; set; }
        public DateTime Date {  get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public User User { get; set; }
    }
}
