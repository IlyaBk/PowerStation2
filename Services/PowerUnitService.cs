using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerStation.Interface;
using PowerStation.Models;

namespace PowerStation.Services
{
    internal class PowerUnitService : IPowerUnit
    {
        private readonly AppDbContext _context;
        public PowerUnitService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<PowerUnit>> AddPowerUnit(PowerUnit request)
        {
            _context.PowerUnits.Add(request);
            await _context.SaveChangesAsync();
            return await GetPowerUnit(request.Name);
        }

        public async Task<ActionResult<int>> DeletePowerUnit(int idPowerUnit)
        {
            var powerUnit = GetPowerUnit(idPowerUnit).Result.Value;
            _context.PowerUnits.Remove(powerUnit);
            await _context.SaveChangesAsync();
            return powerUnit.Id;
        }

        public async Task<ActionResult<PowerUnit>> GetPowerUnit(int idPowerUnit)
        {
            return await _context.PowerUnits.SingleOrDefaultAsync(x => x.Id == idPowerUnit)
                ?? throw new Exception();
        }

        public async Task<ActionResult<PowerUnit>> GetPowerUnit(string namePowerUnit)
        {
            return await _context.PowerUnits.SingleOrDefaultAsync(x => x.Name == namePowerUnit)
                ?? throw new Exception();
        }

        public async Task<ActionResult<PowerUnit>> UpdatePowerUnit(PowerUnit request)
        {
            _context.PowerUnits.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await GetPowerUnit(request.Name);
        }
    }
}
