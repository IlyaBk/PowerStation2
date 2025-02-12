using Microsoft.AspNetCore.Mvc;
using PowerStation.Models;

namespace PowerStation.Interface
{
    internal interface IPowerUnit
    {
        /// <summary>
        /// Добавить новый энергоблок
        /// </summary>
        /// <param name="request">Данные о энергоблоке</param>
        public Task<ActionResult<PowerUnit>> AddPowerUnit(PowerUnit request);

        /// <summary>
        /// Удалить энергоблок
        /// </summary>
        /// <param name="idPowerStation">id станции</param>
        public Task<ActionResult<int>> DeletePowerUnit(int idPowerUnit);

        /// <summary>
        /// Обновить данные о энергоблоке
        /// </summary>
        /// <param name="request"></param>
        public Task<ActionResult<PowerUnit>> UpdatePowerUnit(PowerUnit request);

        /// <summary>
        /// Получить данные о энергоблоке по ИД
        /// </summary>
        /// <param name="idPowerUnit"></param>
        public Task<ActionResult<PowerUnit>> GetPowerUnit(int idPowerUnit);

        /// <summary>
        /// Получить данные о энергоблоке по названию
        /// </summary>
        /// <param name="namePowerUnit"></param>
        public Task<ActionResult<PowerUnit>> GetPowerUnit(string namePowerUnit);
    }
}
