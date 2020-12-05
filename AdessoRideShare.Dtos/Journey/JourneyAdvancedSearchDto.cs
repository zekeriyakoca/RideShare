using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdessoRideShare.Dtos
{
    public class JourneyAdvancedSearchDto
    {
        [Required]
        public int DestinationId { get; set; }

        [Required]
        public int OriginId { get; set; }
    }
}
