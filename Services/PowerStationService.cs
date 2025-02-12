using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerStation.Interface;

namespace PowerStation.Services
{
    public class PowerStationService : IPowerStation
    {
        private readonly AppDbContext _context;
        public PowerStationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Models.PowerStation>> AddPowerStation(Models.PowerStation request)
        {
            _context.PowerStations.Add(request);
            await _context.SaveChangesAsync();
            return await GetPowerStation(request.Name);
        }

        public async Task<ActionResult<int>> DeletePowerStation(int idPowerStation)
        {
            var powerStations = GetPowerStation(idPowerStation).Result.Value;

            await _context.PowerUnits
                .Where(x => x.IdPowerStation == powerStations.Id)
                .ForEachAsync(pu => _context.PowerUnits.Remove(pu));


            _context.PowerStations.Remove(powerStations);
            await _context.SaveChangesAsync();
            return powerStations.Id;
        }

        public async Task<ActionResult<Models.PowerStation>> GetPowerStation(int idPowerStation)
        {
            return await _context.PowerStations.SingleOrDefaultAsync(x => x.Id == idPowerStation)
                ?? throw new Exception();
        }

        public async Task<ActionResult<List<Models.PowerStation>>> GetAllPowerStation()
        {
            return await _context.PowerStations.Include(x => x.PowerUnit).ToListAsync()
                ?? throw new Exception();
        }

        public async Task<ActionResult<Models.PowerStation>> GetPowerStation(string namePowerStation)
        {
            return await _context.PowerStations.SingleOrDefaultAsync(x => x.Name == namePowerStation)
                ?? throw new Exception();
        }

        public async Task<ActionResult<Models.PowerStation>> UpdatePowerStation(Models.PowerStation request)
        {

            _context.PowerStations.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await GetPowerStation(request.Name);

        }
    }
}
