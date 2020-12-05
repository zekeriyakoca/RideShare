using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdessoRideShare.Domain.Entities
{
    [Table("Adventurers")]
    public class Adventurer : User
    {
        public string MSISDN { get; set; }

        public virtual IEnumerable<Journey> Journeys { get; set; }

    }
}
