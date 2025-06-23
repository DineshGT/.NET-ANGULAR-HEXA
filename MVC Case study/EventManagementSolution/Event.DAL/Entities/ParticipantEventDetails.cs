using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Entities
{
    public class ParticipantEventDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("UserInfo")]
        public string ParticipantEmailId { get; set; }

        public UserInfo? UserInfo { get; set; }

        [Required]
        [ForeignKey("EventDetails")]
        public int EventId { get; set; }

        public EventDetails? EventDetails { get; set; }

        [RegularExpression("Yes|No")]
        public string IsAttended { get; set; }
    }

}
