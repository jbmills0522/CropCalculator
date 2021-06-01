using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TomatoCalculator.Server.Data;
using TomatoCalculator.Server.Interfaces;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Repos
{
    public class RouteInformationRepo : IRouteInformationRepo
    {
        private readonly TomatoCalculatorContext _context;

        public RouteInformationRepo(TomatoCalculatorContext context) => _context = context;


        public async Task<List<RouteInformation>> GetAll()
        {
            try
            {
                return await _context.RouteInformations.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RouteInformation> Get(Guid id)
        {
            try
            {
                return await _context.RouteInformations.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RouteInformation> Delete(Guid id)
        {
            try
            {
                var existing = await _context.RouteInformations.FindAsync(id);
                if (existing != null)
                    _context.RouteInformations.Remove(existing);

                await _context.SaveChangesAsync();

                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RouteInformation> Update(RouteInformation route)
        {
            try
            {
                var existing = await _context.RouteInformations.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == route.Id);

                if (existing == null)
                {
                    _context.RouteInformations.Add(route);
                }
                else
                {
                    _context.RouteInformations.Update(route);
                }

                await _context.SaveChangesAsync();

                return route;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}