using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventAppDAL.Entities
{
    

    public class EventDetails
    {
        [Key]
        public int EventId { get; set; }

        [Required, StringLength(50)]
        public string EventName { get; set; }

        [Required, StringLength(50)]
        public string EventCategory { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string? Description { get; set; }

        [Required]
        [RegularExpression("Active|In-Active")]
        public string Status { get; set; }
    }

}
