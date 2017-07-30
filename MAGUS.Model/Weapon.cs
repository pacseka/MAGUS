using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MAGUS.Model
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(RangedWeapon), typeof(MeleeWeapon))]
    public class Weapon
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string Name { get; set; }
        public int Initiate { get; set; }
        public string Damage { get; set; }

        [BsonRequired]
        public int Cost { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }

    public class MeleeWeapon : Weapon
    {
        public int OffenseValue { get; set; }
        public int DefenseValue { get; set; }
    }

    public class RangedWeapon : Weapon
    {
        public int TargetingValue { get; set; }
        public int Range { get; set; }
    }

}
