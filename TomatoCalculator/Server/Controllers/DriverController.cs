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
    public class DriverController
    {
        private readonly IDriverRepo _repo;

        public DriverController(IDriverRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<List<DriverInformation>> Get()
        {
            return await _repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<DriverInformation> Get(Guid id)
        {
            return await _repo.Get(id);
        }

        [HttpDelete("{id}")]
        public async Task<DriverInformation> Delete(Guid id)
        {
            return await _repo.Delete(id);
        }

        [HttpPut]
        public async Task<DriverInformation> Update([FromBody] DriverInformation driverInformation)
        {
            return await _repo.Update(driverInformation);
        }

    }
}