using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdessoRideShare.Dtos
{
    public class JourneyUpsertDto
    {
        public string Description { get; set; }

        [Required]
        public int SeatCapacity { get; set; }

        [Required]
        public DateTime JourneyDate { get; set; }

        public bool IsActive { get; set; }

        public int DestinationId { get; set; }

        public int OriginId { get; set; }
    }
}
