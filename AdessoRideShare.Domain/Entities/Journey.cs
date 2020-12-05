using AdessoRideShare.Dtos.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdessoRideShare.Domain.Entities
{
    public class Journey : BaseEnetity
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public int SeatCapacity { get; set; }
        public int SeatsAllocated { get; set; }
        public DateTime JourneyDate { get; set; }
        public JourneyStatus Status { get; set; }
        public bool IsActive { get; set; }


        [ForeignKey(nameof(Origin))]
        public int OriginId { get; set; }
        public virtual Location Origin { get; set; }

        [ForeignKey(nameof(Destination))]
        public int DestinationId { get; set; }
        public virtual Location Destination { get; set; }


        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public virtual Adventurer Owner { get; set; }

        public virtual IEnumerable<Adventurer> Adventurers { get; set; }

    }
}
