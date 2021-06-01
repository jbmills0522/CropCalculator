using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Interfaces
{
    public interface IShippingRepo
    {
        Task<List<Shipping>> GetAll();
        Task<Shipping> Get(Guid id);
        Task<Shipping> Delete(Guid id);
        Task<Shipping> Update(Shipping shipping);
        Task<List<Shipping>> GetByDriver(int driverNumber);
    }
}