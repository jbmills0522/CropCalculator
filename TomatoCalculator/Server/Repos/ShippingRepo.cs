using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Blazorise.DataGrid;
using Microsoft.EntityFrameworkCore;
using TomatoCalculator.Server.Data;
using TomatoCalculator.Server.Interfaces;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Repos
{
    public class ShippingRepo : IShippingRepo
    {
        private readonly TomatoCalculatorContext _context;
        public ShippingRepo(TomatoCalculatorContext context) => _context = context;
        
        public async Task<List<Shipping>> GetAll()
        {
            try
            {
                return await _context.ShippingLoads.ToListAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Shipping> Get(Guid id)
        {
            try
            {
                return await _context.ShippingLoads.FindAsync(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Shipping> Delete(Guid id)
        {
            try
            {
                var existing = await _context.ShippingLoads.FindAsync(id);
                if (existing != null)
                    _context.ShippingLoads.Remove(existing);

                await _context.SaveChangesAsync();

                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Shipping> Update(Shipping shipping)
        {
            try
            {
                var existing = await _context.ShippingLoads.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == shipping.Id);
                
                if (existing == null)
                {

                    _context.ShippingLoads.Add(shipping);
                }
                else
                {
                    _context.ShippingLoads.Update(shipping);
                }

                await _context.SaveChangesAsync();

                return shipping;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Shipping>> GetByDriver(int driverNumber)
        {
            try
            {
                return await _context.ShippingLoads.Where(x => x.DriverNumber == driverNumber && x.UnloadWeight == 0).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}