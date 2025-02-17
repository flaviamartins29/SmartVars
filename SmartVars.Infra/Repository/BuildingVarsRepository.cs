using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartVars.Domain.Entities;
using SmartVars.Domain.EventHandle.Service;
using SmartVars.Domain.EventHandle.Service.Interfaces;
using SmartVars.Domain.Repository;
using SmartVars.Infra.Data.Context;

namespace SmartVars.Infra.Data.Repository
{
    public class BuildingVarsRepository : IBuildingVarsRepository
    {
        private readonly SmartVarsContext _context;
        private readonly ILogger<BuildingVarsRepository> _logger;
        private readonly ICommandEventHandle<CreateEventHandle> _eventCreateHandle;
        private readonly ICommandEventHandle<UpdateEventHandle> _eventUpdateHandle;

        public BuildingVarsRepository(SmartVarsContext context, ILogger<BuildingVarsRepository> logger, ICommandEventHandle<CreateEventHandle> eventHandle)
        {
            _context = context;
            _logger = logger;
            _eventCreateHandle = eventHandle;
        }
        public async Task<BuildingVars> CreateNewVarsAsync(BuildingVars buildingVars)
        {
            try
            {
                _context.Add(buildingVars);
                await _context.SaveChangesAsync();
                await _eventCreateHandle.Dispatch(new CreateEventHandle(buildingVars));
                _logger.LogInformation($"Your {buildingVars.Id} created");

                return buildingVars;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while create a new var");
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
                if (yourVar == null)
                    _logger.LogInformation($"Your {id} was found");

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
                if(buildingVars == null)
                    _logger.LogWarning($"Your {buildingVars.Id} was not found");

                _context.Update(buildingVars);
                await _context.SaveChangesAsync();
                await _eventUpdateHandle.Dispatch(new UpdateEventHandle(buildingVars));
                _logger.LogInformation($"Your {buildingVars.Id} was updated");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while update the id: {buildingVars.Id}");
                throw;
            }
        }
    }
}