using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pi.Core.Entity;
using Pi.Core.Services;

namespace Pi.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppusersController : ControllerBase
    {
        private readonly IService<Appuser> _appuserService;

        public AppusersController(IService<Appuser> service)
        {
            _appuserService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _appuserService.Where(x=>x.IsDelete!=false);
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Appuser appuser)

        {
            var newperson = await _appuserService.AddAsync(appuser);

            return Ok(newperson);
        }
    }
}
