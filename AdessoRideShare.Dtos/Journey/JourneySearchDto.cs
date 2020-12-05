using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdessoRideShare.Dtos
{
    public class JourneySearchDto
    {
        public int? DestinationId { get; set; }

        public int? OriginId { get; set; }
    }
}
