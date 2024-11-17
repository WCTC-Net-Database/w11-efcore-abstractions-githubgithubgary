using ConsoleRpgEntities.Items;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable, IPlayer
    {
        public int Experience { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public virtual IEnumerable<Ability> Abilities { get; set; }
        // TODO
        // This should be a list instead of a set record.
        // Talk with instructor about how to navigate the list instead.
        public virtual Items.Equipment? Equipment { get; set; }
        public void Attack(ITargetable target)
        {
            // Player-specific attack logic
            if (Equipment == null)
            {
                Console.WriteLine($"{Name} attacks {target.Name} with their bare hands");
            }
            else
            {
                // Can no longer use the weapon since it has no health, damaged and must be repaired.
                if (Equipment.WeaponHealth == 0)
                {
                    Console.WriteLine($"{Name} attacks {target.Name} with their bare hands because the {Equipment.Weapon.Description} needs repair.");
                }
                else
                {
                    Console.WriteLine($"{Name} attacks {target.Name} with a {Equipment.Weapon.Description} and takes {Equipment.Weapon.Damage} hitpoints of damage!");

                    Random random = new Random();
                    if (random.Next(0, 2) == 1)
                    {
                        // Did not use the assigned damage from the item table but did random damage
                        // Seems more realistic
                        int dmg = random.Next(0, 10);
                        if (dmg > 0)
                        {
                            Equipment.WeaponTakeDamage(dmg);
                            Console.WriteLine($"{Name} {Equipment.Weapon.Description} takes {dmg} hit points of damage, its health is now at {Equipment.WeaponHealth}!");
                        }
                    }
                }
            }
        }
        public void TakeDamage(int damage)
        {
            if (damage > Health)
            {
                Console.WriteLine($"{Name} takes a critical hit and dies.");
                // We would need to do something with the character like remove them from game play etc.
                // Currently the player can continue play without any health/hit points
            }
            else
            {
                Health = Health - damage;
                Console.WriteLine($"{Name} takes a hit for {damage} and is left with {Health} hit points.");
            }
        }

        public void UseAbility(IAbility ability, ITargetable target)
        {
            if (Abilities.Contains(ability))
            {
                ability.Activate(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} does not have the ability {ability.Name}!");
            }
        }
    }
}
