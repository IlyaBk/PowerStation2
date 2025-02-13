using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerStation;
using PowerStation.Models;
using PowerStation.Services;

namespace PowerStation2.Controllers
{
    /// <summary>
    /// Операции для работы с даннымы энергоблока
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PowerUnitController : ControllerBase
    {
        private readonly AppDbContext _context;

        private PowerUnitService powerUnitService
            => new PowerUnitService(_context);

        /// <summary>
        /// Операции для работы с даннымы энергоблока
        /// </summary>
        /// <param name="context"></param>
        public PowerUnitController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить данные о энергоблоке по ИД
        /// </summary>
        /// <param name="idPowerUnit"></param>
        /// <returns></returns>
        [HttpGet("GetPowerUnit")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<PowerUnit>> GetPowerUnit(int idPowerUnit)
        {
            return await ErrorHandlingWrapper(async ()
                => await powerUnitService.GetPowerUnit(idPowerUnit));
        }

        /// <summary>
        /// Получить данные о энергоблоке по назвнию
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("GetPowerUnitForName")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<PowerUnit>> GetPowerUnit(string name)
        {
            return await ErrorHandlingWrapper(async ()
                => await powerUnitService.GetPowerUnit(name));
        }

        /// <summary>
        /// Добавить новый энергоблок
        /// </summary>
        /// <param name="powerUnit"></param>
        /// <returns></returns>
        [HttpPost("AddPowerUnit")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PowerUnit>> AddPowerUnit(PowerUnit powerUnit)
        {
            return await ErrorHandlingWrapper(async ()
                => await powerUnitService.AddPowerUnit(powerUnit));
        }

        /// <summary>
        /// Обновить данные о энергоблоке
        /// </summary>
        /// <param name="powerUnit"></param>
        /// <returns></returns>
        [HttpPut("UpdatePowerUnit")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PowerUnit>> UpdatePowerUnit(PowerUnit powerUnit)
        {
            return await ErrorHandlingWrapper(async ()
                => await powerUnitService.UpdatePowerUnit(powerUnit));
        }

        /// <summary>
        /// Удалить энергоблок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeletePowerUnit")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<int>> DeletePowerUnit(int id)
        {
            return await ErrorHandlingWrapper(async ()
                => await powerUnitService.DeletePowerUnit(id));
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
