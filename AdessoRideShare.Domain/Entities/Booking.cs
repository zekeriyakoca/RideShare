using AdessoRideShare.Dtos.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdessoRideShare.Domain.Entities
{
    public class Booking : BaseEnetity
    {
        [Key]
        public int Id { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        
        [Required]
        [ForeignKey(nameof(Journey))]
        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
        
        [Required]
        [ForeignKey(nameof(Adventurer))]
        public int AdventurerId { get; set; }
        public Adventurer Adventurer { get; set; }

    }
}
