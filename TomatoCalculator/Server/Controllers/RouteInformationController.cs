using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TomatoCalculator.Server.Interfaces;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RouteInformationController : ControllerBase
    {
        private readonly IRouteInformationRepo _repo;

        public RouteInformationController(IRouteInformationRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<List<RouteInformation>> Get()
        {
            return await _repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<RouteInformation> Get(Guid id)
        {
            return await _repo.Get(id);
        }

        [HttpDelete("{id}")]
        public async Task<RouteInformation> Delete(Guid id)
        {
            return await _repo.Delete(id);
        }

        [HttpPut]
        public async Task<RouteInformation> Update([FromBody] RouteInformation route)
        {
            return await _repo.Update(route);
        }
    }
}