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
    
    public class ShippingController : ControllerBase
    {
        private readonly IShippingRepo _repo;

        public ShippingController(IShippingRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<List<Shipping>> Get()
        {
            return await _repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Shipping> Get(Guid id)
        {
            return await _repo.Get(id);
        }

        [HttpDelete("{id}")]
        public async Task<Shipping> Delete(Guid id)
        {
            return await _repo.Delete(id);
        }

        [HttpPut]
        public async Task<Shipping> Update([FromBody] Shipping shipping)
        {
            return await _repo.Update(shipping);
        }

        [HttpGet("byDriver/{driverNumber}")]
        public async Task<List<Shipping>> GetByDriver(int driverNumber)
        {
            return await _repo.GetByDriver(driverNumber);
        }
    }
}