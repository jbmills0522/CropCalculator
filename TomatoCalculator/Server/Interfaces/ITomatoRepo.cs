using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Interfaces
{
    public interface ITomatoRepo
    {
        Task<List<Tomato>> GetAll();
        Task<Tomato> Get(Guid id);
        Task<Tomato> Delete(Guid id);
        Task<Tomato> Update(Tomato tomato);
    }
}