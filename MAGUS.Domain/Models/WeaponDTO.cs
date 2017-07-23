using System;
using MAGUS.Domain.Interfaces;

namespace MAGUS.Domain
{
    public class WeaponDTO : IWeaponDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Initiate { get; set; }
        public string Damage { get; set; }
        public int Cost { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
