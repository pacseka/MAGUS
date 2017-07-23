namespace MAGUS.Domain.Interfaces
{
    public interface IWeaponDTO
    {
        string Damage { get; set; }
        string Description { get; set; }
        string ID { get; set; }
        int Initiate { get; set; }
        string Name { get; set; }
        int Cost { get; set; }
        string Type { get; set; }
        decimal Weight { get; set; }
    }
}