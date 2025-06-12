using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAppDAL.Models
{
    public class SessionInfo
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        [ForeignKey("EventDetails")]
        public int EventId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string SessionTitle { get; set; }

        [ForeignKey("SpeakersDetails")]
        public int? SpeakerId { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime SessionStart { get; set; }

        [Required]
        public DateTime SessionEnd { get; set; }

        public string? SessionUrl { get; set; }

        public virtual EventDetails? EventDetails { get; set; }
        public virtual SpeakersDetails? SpeakersDetails { get; set; }
    }
}
