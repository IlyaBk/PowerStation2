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

        public Models.PowerStation AddPowerStation(Models.PowerStation request)
        {
            _context.PowerStations.Add(request);
            _context.SaveChanges();
            return GetPowerStation(request.Name);
        }

        public int DeletePowerStation(int idPowerStation)
        {
            var powerStations = GetPowerStation(idPowerStation);
            _context.PowerUnits
                .Where(x => x.IdPowerStation == powerStations.Id)
                .ForEachAsync(pu => _context.PowerUnits.Remove(pu));
            _context.PowerStations.Remove(powerStations);
            _context.SaveChanges();
            return powerStations.Id;
        }

        public Models.PowerStation GetPowerStation(int idPowerStation)
        {
            return _context.PowerStations.FirstOrDefault(x => x.Id == idPowerStation)
                ?? throw new Exception();
        }

        public List<Models.PowerStation> GetAllPowerStation()
        {
            return _context.PowerStations.Include(x => x.PowerUnit).ToList()
                ?? throw new Exception();
        }

        public Models.PowerStation GetPowerStation(string namePowerStation)
        {
            return _context.PowerStations.FirstOrDefault(x => x.Name == namePowerStation)
                ?? throw new Exception();
        }

        public Models.PowerStation UpdatePowerStation(Models.PowerStation request)
        {
            _context.PowerStations.Entry(request).State = EntityState.Modified;
            _context.SaveChanges();
            return GetPowerStation(request.Name);

        }
    }
}
