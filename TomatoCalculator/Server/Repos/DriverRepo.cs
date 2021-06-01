using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TomatoCalculator.Server.Data;
using TomatoCalculator.Server.Interfaces;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Repos
{
    public class DriverRepo : IDriverRepo
    {
        private readonly TomatoCalculatorContext _context;

        public DriverRepo(TomatoCalculatorContext context) => _context = context;


        public async Task<List<DriverInformation>> GetAll()
        {
            try
            {
                return await _context.DriverInformations.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<DriverInformation> Get(Guid id)
        {
            try
            {
                return await _context.DriverInformations.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<DriverInformation> Delete(Guid id)
        {
            try
            {
                var existing = await _context.DriverInformations.FindAsync(id);
                if (existing != null)
                    _context.DriverInformations.Remove(existing);

                await _context.SaveChangesAsync();

                return existing;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<DriverInformation> Update(DriverInformation driverInformation)
        {
            try
            {
                var existing = await _context.DriverInformations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == driverInformation.Id);
                if (existing == null)
                {
                    _context.DriverInformations.Add(driverInformation);
                }
                else
                {
                    _context.DriverInformations.Update(driverInformation);
                }

                await _context.SaveChangesAsync();

                return driverInformation;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}