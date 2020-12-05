using AdessoRideShare.Dtos.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdessoRideShare.Domain.Entities
{
    public class Journey : BaseEnetity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        [Required]
        public int SeatCapacity { get; set; }
        public int SeatsAllocated { get; set; }

        [Required]
        public DateTime JourneyDate { get; set; }

        [Required]
        public JourneyStatus Status { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(Origin))]
        public int? OriginId { get; set; }
        public virtual Location Origin { get; set; }

        [ForeignKey(nameof(Destination))]
        public int? DestinationId { get; set; }
        public virtual Location Destination { get; set; }

        [Required]
        [ForeignKey(nameof(Boss))]
        public int OwnerId { get; set; }
        public virtual Boss Boss { get; set; }

        public virtual IEnumerable<Adventurer> Adventurers { get; set; }

    }
}
