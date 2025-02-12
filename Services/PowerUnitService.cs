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
            throw new NotImplementedException();
        }

        public int DeletePowerUnit(int idPowerUnit)
        {
            throw new NotImplementedException();
        }

        public List<PowerUnit> GetPowerUnit(int idPowerUnit)
        {
            throw new NotImplementedException();
        }

        public List<PowerUnit> GetPowerUnit(string namePowerUnit)
        {
            throw new NotImplementedException();
        }

        public List<PowerUnit> UpdatePowerUnit(PowerUnit request)
        {
            throw new NotImplementedException();
        }
    }
}
