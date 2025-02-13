using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerStation;
using PowerStation.Services;

namespace PowerStation2.Controllers
{
    /// <summary>
    /// Контроллер для работы операций с данными о станции
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PowerStationController : ControllerBase
    {
        private readonly AppDbContext _context;

        private PowerStationService powerStationService
            => new PowerStationService(_context);

        /// <summary>
        /// Контроллер для работы операций с данными о станции
        /// </summary>
        /// <param name="context"></param>
        public PowerStationController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить список всех электростанций
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPowerStation")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<List<PowerStation.Models.PowerStation>>> GetAllPowerStation()
        {
            return await ErrorHandlingWrapper(async ()
            => await powerStationService.GetAllPowerStation());
        }

        /// <summary>
        /// Получить данные о станции по ИД
        /// </summary>
        /// <param name="idPowerStation"></param>
        [HttpGet("GetPowerStationForId")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<PowerStation.Models.PowerStation>> GetPowerStation(int idPowerStation)
        {
            return await ErrorHandlingWrapper(async ()
                => await powerStationService.GetPowerStation(idPowerStation));
        }

        /// <summary>
        /// Получить данные о станции по названию
        /// </summary>
        /// <param name="namePowerStation"></param>
        [HttpGet("GetPowerStation")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<PowerStation.Models.PowerStation>> GetPowerStation(string name)
        {
            return await ErrorHandlingWrapper(async ()
                => await powerStationService.GetPowerStation(name));
        }

        /// <summary>
        /// Добавить новую станцию
        /// </summary>
        /// <param name="request">Данные о станции</param>
        [HttpPost("AddPowerStation")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PowerStation.Models.PowerStation>> AddPowerStation(PowerStation.Models.PowerStation station)
        {
            return await ErrorHandlingWrapper(async ()
                => await powerStationService.AddPowerStation(station));
        }

        /// <summary>
        /// Обновить данные о станции
        /// </summary>
        /// <param name="request"></param>
        [HttpPut("UpdatePowerStation")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PowerStation.Models.PowerStation>> UpdatePowerStation
            (PowerStation.Models.PowerStation station)
        {
            return await ErrorHandlingWrapper(async ()
                => await powerStationService.UpdatePowerStation(station));
        }

        /// <summary>
        /// Удалить станцию
        /// </summary>
        /// <param name="idPowerStation">id станции</param>
        [HttpDelete("DeletePowerStation")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<int>> DeletePowerStation(int idPowerStation)
        {
            return await ErrorHandlingWrapper(async ()
                => await powerStationService.DeletePowerStation(idPowerStation));
        }

        /// <summary>
        /// Обработчик исключений
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<ActionResult<T>> ErrorHandlingWrapper<T>(Func<Task<ActionResult<T>>> action)
        {
            try
            {
                return Ok(await action());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
