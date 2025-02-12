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

        public PowerUnit AddPowerUnit(PowerUnit request)
        {
            _context.PowerUnits.Add(request);
            _context.SaveChanges();
            return GetPowerUnit(request.Name);
        }

        public int DeletePowerUnit(int idPowerUnit)
        {
            var powerUnit = GetPowerUnit(idPowerUnit);
            _context.PowerUnits.Remove(powerUnit);
            _context.SaveChanges();
            return powerUnit.Id;
        }

        public PowerUnit GetPowerUnit(int idPowerUnit)
        {
            return _context.PowerUnits.FirstOrDefault(x => x.Id == idPowerUnit)
                ?? throw new Exception();
        }

        public PowerUnit GetPowerUnit(string namePowerUnit)
        {
            return _context.PowerUnits.FirstOrDefault(x => x.Name == namePowerUnit)
                ?? throw new Exception();
        }

        public PowerUnit UpdatePowerUnit(PowerUnit request)
        {
            _context.PowerUnit.Entry(request).State = EntityState.Modified;
            _context.SaveChanges();
            return GetPowerUnit(request.Name);
        }
    }
}
