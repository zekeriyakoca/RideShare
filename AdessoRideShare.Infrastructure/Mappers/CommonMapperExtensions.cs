using AdessoRideShare.Domain.Entities;
using AdessoRideShare.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdessoRideShare.Infrastructure.Mappers
{
    public static class CommonMapperExtensions
    {
        public static Journey ToJourney(this JourneyUpsertDto dto, User user)
        {
            return new Journey
            {
                OwnerId = user.Id,
                Status = Dtos.Enums.JourneyStatus.Cretad,
                Description = dto.Description,
                DestinationId = dto.DestinationId,
                OriginId = dto.OriginId,
                JourneyDate = dto.JourneyDate,
                IsActive = dto.IsActive,
                SeatCapacity = dto.SeatCapacity
            };
        }
        public static Amigo ToAmigo(this AmigoDto dto)
        {
            return new Amigo
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
        }

        public static List<Amigo> ToAmigoList(this IEnumerable<AmigoDto> dto)
        {
            return dto.Select(d => d.ToAmigo()).ToList();

        }

    }
}
