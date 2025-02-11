namespace PowerStation.Models
{
    public class PowerUnit
    {
        public int Id { get; set; }
        public int IdPowerStation { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime NextMaintenanceDate { get; set; }
        public int SensorCount { get; set; }
    }
}
