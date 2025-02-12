using Microsoft.AspNetCore.Mvc;

namespace PowerStation.Interface
{
    /// <summary>
    /// Операции для работы с данными о станции
    /// </summary>
    public interface IPowerStation
    {
        /// <summary>
        /// Добавить новую станцию
        /// </summary>
        /// <param name="request">Данные о станции</param>
        public Task<ActionResult<Models.PowerStation>> AddPowerStation(Models.PowerStation request);

        /// <summary>
        /// Удалить станцию
        /// </summary>
        /// <param name="idPowerStation">id станции</param>
        public Task<ActionResult<int>> DeletePowerStation(int idPowerStation);

        /// <summary>
        /// Обновить данные о станции
        /// </summary>
        /// <param name="request"></param>
        public Task<ActionResult<Models.PowerStation>> UpdatePowerStation(Models.PowerStation request);

        /// <summary>
        /// Получить данные о станции по ИД
        /// </summary>
        /// <param name="idPowerStation"></param>
        public Task<ActionResult<Models.PowerStation>> GetPowerStation(int idPowerStation);

        /// <summary>
        /// Получить данные о станции по названию
        /// </summary>
        /// <param name="namePowerStation"></param>
        public Task<ActionResult<Models.PowerStation>> GetPowerStation(string namePowerStation);

        /// <summary>
        /// Получить список всех станций
        /// </summary>
        /// <returns></returns>
        public Task<ActionResult<List<Models.PowerStation>>> GetAllPowerStation();
    }
}
