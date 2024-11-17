using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Items
{
    public class Equipment
    {
        public int Id { get; set; }
        public virtual Player Player { get; set; }
        public int PlayerID { get; set; }
        public virtual Weapon? Weapon { get; set; }
        public int? WeaponID { get; set; }
        public int WeaponHealth {  get; set; }
        public virtual Armor? Armor { get; set; }
        public int? ArmorID { get; set; }
        public int ArmorHealth { get; set; }

        // TODO
        // these methods would get messy, don't like it but it works for now.
        // Talk with instructor about better way to handle
        public void ArmorHeal(int hitpoints)
        {
            ArmorHealth = ArmorHealth + hitpoints;
        }
        public void ArmorTakeDamage(int hitpoints)
        {
            if (ArmorHealth > hitpoints)
            {
                ArmorHealth = ArmorHealth - hitpoints;
            }
            else
            {
                ArmorHealth = 0;
            }
        }
        public void WeaponHeal(int hitpoints)
        {
            WeaponHealth = WeaponHealth + hitpoints;
        }
        public void WeaponTakeDamage(int hitpoints)
        {
            if (WeaponHealth > hitpoints)
            {
                WeaponHealth = WeaponHealth - hitpoints;
            }
            else
            {
                WeaponHealth = 0;
            }
        }
    }
}