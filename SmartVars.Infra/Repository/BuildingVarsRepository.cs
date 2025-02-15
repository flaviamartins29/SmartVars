using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartVars.Domain.Entities;
using SmartVars.Domain.Repository;
using SmartVars.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Infra.Data.Repository
{
    public class BuildingVarsRepository : IBuildingVarsRepository
    {
        private readonly SmartVarsContext _context;

        public BuildingVarsRepository(SmartVarsContext context) 
        {
            _context = context;
        }
        public async Task<BuildingVars> CreateNewVarsAsync(BuildingVars buildingVars)
        {
            _context.Add(buildingVars);
            await _context.SaveChangesAsync();
            return buildingVars;
        }

        public async Task DeleteVarByIdAsync(BuildingVars buildingVars)
        {
            _context.Remove(buildingVars);
            await _context.SaveChangesAsync();   
        }
        public async Task<ICollection<BuildingVars>> GetAllVarsListAsync()
        {
           return await _context.BuildingVars.ToListAsync();
        }

        public async  Task<BuildingVars> GetVarByIdAsync(int id)
        {
            var yourVar = await _context.BuildingVars.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (_context.BuildingVars.Any(x => x.Id == id)) 
                LogLevel.Information.ToString($"Your {id} was found");

            }
            catch (Exception ex)
            {

                throw;
            }


            return yourVar;

        }

        public async Task UpdateVarByIdAsync(BuildingVars buildingVars)
        {
            _context.Update(buildingVars);
            await _context.SaveChangesAsync();

        }
    }
}
