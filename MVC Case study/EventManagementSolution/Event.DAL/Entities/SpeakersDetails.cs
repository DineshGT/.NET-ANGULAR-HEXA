using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Entities
{
    public class SpeakersDetails
    {
        [Key]
        public int SpeakerId { get; set; }

        [Required, StringLength(50)]
        public string SpeakerName { get; set; }
    }

}
