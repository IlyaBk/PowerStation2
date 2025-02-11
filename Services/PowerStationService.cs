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

        public int AddPowerStation(Models.PowerStation request)
        {
            throw new NotImplementedException();
        }

        public int DeletePowerStation(int idPowerStation)
        {
            throw new NotImplementedException();
        }

        public List<Models.PowerStation> GetPowerStation(int idPowerStation)
        {
            throw new NotImplementedException();
        }

        public List<Models.PowerStation> GetPowerStation(string namePowerStation)
        {
            throw new NotImplementedException();
        }

        public List<Models.PowerStation> UpdatePowerStation(Models.PowerStation request)
        {
            throw new NotImplementedException();
        }
    }
}
