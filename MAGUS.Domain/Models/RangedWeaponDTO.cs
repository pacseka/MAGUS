using System.ComponentModel.DataAnnotations;

namespace MAGUS.Domain
{
    public class RangedWeaponDTO: WeaponDTO
    {
        [Required]
        public int TargetingValue { get; set; }

        [Required]
        public int Range { get; set; }
    }
}
