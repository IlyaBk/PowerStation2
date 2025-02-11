using PowerStation.Models;

namespace PowerStation.Interface
{
    internal interface IPowerUnit
    {
        /// <summary>
        /// Добавить новую станцию
        /// </summary>
        /// <param name="request">Данные о станции</param>
        public void AddPowerUnit(PowerUnit request);

        /// <summary>
        /// Удалить станцию
        /// </summary>
        /// <param name="idPowerStation">id станции</param>
        public bool DeletePowerUnit(int idPowerStation);

        /// <summary>
        /// Обновить данные о станции
        /// </summary>
        /// <param name="idPowerStation"></param>
        public bool UpdatePowerUnit(PowerUnit request);

        /// <summary>
        /// Получить данные о станции по ИД
        /// </summary>
        /// <param name="idPowerStation"></param>
        public PowerUnit GetPowerUnit(int idPowerUnit);

        /// <summary>
        /// Получить данные о станции по названию
        /// </summary>
        /// <param name="idPowerStation"></param>
        public PowerUnit GetPowerUnit(string namePowerUnit);
    }
}
