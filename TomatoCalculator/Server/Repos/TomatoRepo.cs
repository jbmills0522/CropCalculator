using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TomatoCalculator.Server.Data;
using TomatoCalculator.Server.Interfaces;
using TomatoCalculator.Shared.Helpers;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Repos
{
    public class TomatoRepo : ITomatoRepo
    {
        private readonly TomatoCalculatorContext _context;
        public TomatoRepo(TomatoCalculatorContext context) => _context = context;
        
        public async Task<List<Tomato>> GetAll()
        {
            try
            {
                return await _context.Tomatoes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Tomato> Get(Guid id)
        {
            try
            {
                return await _context.Tomatoes.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Tomato> Delete(Guid id)
        {
            try
            {
                var existing = await _context.Tomatoes.FindAsync(id);
                if (existing != null)
                    _context.Tomatoes.Remove(existing);

                await _context.SaveChangesAsync();

                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Tomato> Update(Tomato tomato)
        {
            try
            {
                var existing = await _context.Tomatoes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tomato.Id);

                if (existing == null)
                {
                    _context.Tomatoes.Add(tomato);
                }
                else
                {
                    _context.Tomatoes.Update(tomato);
                }

                await _context.SaveChangesAsync();

                return tomato;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}