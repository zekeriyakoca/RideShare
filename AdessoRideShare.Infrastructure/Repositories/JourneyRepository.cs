using AdessoRideShare.Domain.Entities;
using AdessoRideShare.Domain.Interfaces;
using AdessoRideShare.Infrastructure.EntityFramework.Context;
using AdessoRideShare.Utils.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Infrastructure.Repositories
{
    public class JourneyRepository : Repository<Journey>, IJourneyRepository
    {
        private readonly DataContext context;

        public JourneyRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task SetStatus(int id, bool isActive) {
            var journey = await Get(id);
            if (journey == null) {
                throw new BusinessException("Journey not found!");
            }
            journey.IsActive = isActive;
        }

        public async Task<Journey> GetWithBookings(int id)
        {
            return  context.Journeys.Include(j=>j.Bookings).FirstOrDefault(j=>j.Id == id);
        }



    }
}
