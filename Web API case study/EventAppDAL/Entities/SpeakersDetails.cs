using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventAppDAL.Entities
{
    

    public class SpeakersDetails
    {
        [Key]
        public int SpeakerId { get; set; }

        [Required, StringLength(50)]
        public string SpeakerName { get; set; }
    }

}
