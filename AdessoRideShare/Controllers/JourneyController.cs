﻿using AdessoRideShare.Domain.Entities;
using AdessoRideShare.Domain.Interface;
using AdessoRideShare.Domain.Interfaces;
using AdessoRideShare.Dtos;
using AdessoRideShare.Infrastructure.Mappers;
using AdessoRideShare.Utils;
using AdessoRideShare.Utils.Infrastructure;
using Cache.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Controllers
{
    // TODO : DO NOT EXPOSE Entity Models
    [ApiController]
    [Route("[controller]")]
    public class JourneyController : BaseController
    {

        private readonly ILogger<JourneyController> logger;
        private readonly IBookingRepository bookingRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IJourneyRepository journeyRepository;
        public IUnitOfWork unitOfWork { get; }

        public JourneyController(ILogger<JourneyController> logger,
            ICacheService cacheService,
            IJourneyRepository journeyRepository,
            IBookingRepository bookingRepository,
            ILocationRepository locationRepository,
            IUnitOfWork unitOfWork
            ) : base(cacheService)
        {
            this.logger = logger;
            this.journeyRepository = journeyRepository;
            this.bookingRepository = bookingRepository;
            this.locationRepository = locationRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateNewJourney([FromBody] JourneyUpsertDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.journeyRepository.Add(dto.ToJourney(CurrentUser));
            await this.unitOfWork.Complete();
            return Ok();
        }

        [HttpPut]
        [Route("{journeyId}/updateStatus")]
        public async Task<ActionResult> UpdateJourneyStatus(int journeyId, [FromBody] bool isActive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await this.journeyRepository.SetStatus(journeyId, isActive);
            await this.unitOfWork.Complete();

            return Ok();
        }


        [HttpPost]
        [Route("search")]
        public ActionResult<List<JourneyDto>> SearchJourney([FromBody] JourneySearchDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var journeys = journeyRepository.GetAllLazy();
            if (dto.OriginId != null)
            {
                journeys = journeys.Where(j => j.OriginId == dto.OriginId);
            }
            if (dto.DestinationId != null)
            {
                journeys = journeys.Where(j => j.DestinationId == dto.DestinationId.Value);
            }
            return Ok(journeys.ToList());
        }

        [HttpPost]
        [Route("searchadvanced")]
        public async Task<ActionResult<List<JourneyDto>>> SearchJourney2([FromBody] JourneyAdvancedSearchDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var origin = await locationRepository.Get(dto.OriginId);
            var destination = await locationRepository.Get(dto.DestinationId);
            if (origin == null || destination == null)
                return NotFound("");

            // TODO : Send/Get all active the journeys into/from Redis
            var journeys = journeyRepository.GetAllLazy();
            
            var eligibleJourneys = journeys.ToList().Where(j => j.IsActive && CoordinateHelper.IsBetween(
                 new Coordinate { X = origin.CoorditateX, Y = origin.CoorditateY },
                 new Coordinate { X = destination.CoorditateX, Y = destination.CoorditateY },
                 new Coordinate { X = j.Origin.CoorditateX, Y = j.Origin.CoorditateY },
                 new Coordinate { X = j.Destination.CoorditateX, Y = j.Destination.CoorditateY }
            ));

            return Ok(eligibleJourneys.ToList());
        }

        [HttpPost]
        [Route("{id}/join")]
        public async Task<ActionResult<List<JourneyDto>>> JoinToJourney([FromRoute] int id, [FromBody] List<AmigoDto> amigos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var journey = await journeyRepository.GetWithBookings(id);

            if (journey == null || !journey.isEligableToJoin)
            {
                return BadRequest("Journey is already full");
            }
            //TODO : Move these domain related staff to repository
            var booking = new Booking { AdventurerId = 2, JourneyId = id, CreatedTime = DateTime.Now, Status = Dtos.Enums.BookingStatus.Cretaed }; // TODO : Replace with CurrentUser after the authentication system implemented
            booking.Amigos = amigos.ToAmigoList();

            bookingRepository.Add(booking);
            await unitOfWork.Complete();
            return Ok();
        }
    }
}
