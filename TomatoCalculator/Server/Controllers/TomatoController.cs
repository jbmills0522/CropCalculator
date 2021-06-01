using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TomatoCalculator.Server.Interfaces;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TomatoController : ControllerBase
    {
        private readonly ITomatoRepo _repo;

        public TomatoController(ITomatoRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<List<Tomato>> Get()
        {
            return await _repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Tomato> Get(Guid id)
        {
            return await _repo.Get(id);
        }

        [HttpDelete("{id}")]
        public async Task<Tomato> Delete(Guid id)
        {
            return await _repo.Delete(id);
        }

        [HttpPut]
        public async Task<Tomato> Update([FromBody] Tomato tomato)
        {
            return await _repo.Update(tomato);
        }
    }
}