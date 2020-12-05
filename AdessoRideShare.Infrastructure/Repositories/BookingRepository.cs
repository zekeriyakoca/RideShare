using AdessoRideShare.Domain.Entities;
using AdessoRideShare.Domain.Interfaces;
using AdessoRideShare.Infrastructure.EntityFramework.Context;
using AdessoRideShare.Utils.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Infrastructure.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly DataContext context;

        public BookingRepository(DataContext context) : base(context)
        {
            this.context = context;
        }



    }
}
