using AdessoRideShare.Domain.Entities;
using AdessoRideShare.Dtos.Enums;
using Cache.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly ICacheService cacheService;

        public BaseController(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }
        private User _user { get; set; }
        protected User CurrentUser
        {
            get
            {
                if (_user == null) {
                    this._user = (User)cacheService.GetValue<Boss>(CacheKeys.CurrentUser).Result;
                }
                return _user;
            }
        }
    }
}
