using AdessoRideShare.Domain.Entities;
using AdessoRideShare.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Domain.Interfaces
{
    public interface IJourneyRepository : IRepository<Journey>
    {
        Task SetStatus(int id, bool isActive);
        Task<Journey> GetWithBookings(int id);


    }
}
