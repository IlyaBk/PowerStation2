using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerStation;
using PowerStation.Services;

namespace PowerStation2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PowerStationController : ControllerBase
    {
        private readonly AppDbContext _context;

        private PowerStationService powerStationService
            => new PowerStationService(_context);

        public PowerStationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public List<PowerStation.Models.PowerStation> GetPowerStation(int idPowerStation)
        {
            return powerStationService.GetPowerStation(idPowerStation);
        }

        [HttpGet("{name}")]
        [Authorize(Roles = "User")]
        public List<PowerStation.Models.PowerStation> GetPowerStation(string name)
        {
            return powerStationService.GetPowerStation(name);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public int AddPowerStation(PowerStation.Models.PowerStation station)
        {
            return powerStationService.AddPowerStation(station);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public List<PowerStation.Models.PowerStation> PutStation
            (PowerStation.Models.PowerStation station)
        {
            return powerStationService.UpdatePowerStation(station);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public int DeleteStation(int id)
        {
            return powerStationService.DeletePowerStation(id);
        }
    }
}
