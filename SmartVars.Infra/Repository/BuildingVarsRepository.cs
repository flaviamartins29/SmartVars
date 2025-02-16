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

        private readonly ILogger<BuildingVarsRepository> _logger;

        public BuildingVarsRepository(SmartVarsContext context, ILogger<BuildingVarsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<BuildingVars> CreateNewVarsAsync(BuildingVars buildingVars)
        {

            try
            {
                _context.Add(buildingVars);
                await _context.SaveChangesAsync();
                return buildingVars;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while create a new var");
                throw;
            }
        }

        public async Task DeleteVarByIdAsync(BuildingVars buildingVars)
        {
            try
            {
                _context.Remove(buildingVars);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while delete the id: {buildingVars.Id}");
                throw;
            }
            
        }
        public async Task<ICollection<BuildingVars>> GetAllVarsListAsync()
        {

            return await _context.BuildingVars.ToListAsync();
        }

        public async Task<BuildingVars> GetVarByIdAsync(int id)
        {
            try
            {
                var yourVar = await _context.BuildingVars.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (yourVar != null)
                {
                    _logger.LogInformation($"Your {id} was found");
                }
                else
                {
                    _logger.LogWarning($"Your {id} was not found");
                }

                return yourVar;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving {id}");
                throw;
            }
        }
        public async Task UpdateVarByIdAsync(BuildingVars buildingVars)
        {
            try
            {
                _context.Update(buildingVars);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while update the id: {buildingVars.Id}");
                throw;
            }
            

        }
    }
}
