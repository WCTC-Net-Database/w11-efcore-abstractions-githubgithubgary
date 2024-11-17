using ConsoleRpgEntities.Models.Attributes;

namespace ConsoleRpgEntities.Models.Characters.Monsters
{
    public class Goblin : Monster
    {
        public int Sneakiness { get; set; }

        public override void Attack(ITargetable target)
        {
            // Goblin-specific attack logic
            Console.WriteLine($"{Name} sneaks up and attacks {target.Name}!");
            Random random = new Random();
            if (random.Next(0, 2) == 0)
            {
                Console.WriteLine($"{target.Name} detects {Name} and deflects the attach!");
            }
            else
            {
                if (target is Player player)
                {
                    Random dmg = new Random();
                    int damage = dmg.Next(0, 11);
                    if (damage == 0)
                    {
                        Console.WriteLine($"{player.Name} deflects the attach by {Name} and takes no damage.");
                    }
                    else
                    {
                        if ((player.Equipment != null) && (player.Equipment.Armor != null) && (player.Equipment.Armor.Protection > damage))
                        {
                            Console.WriteLine($"{player.Name}'s {player.Equipment.Armor.Description} armor deflects the the attach and takes no damage.");
                        }
                        else
                        {
                            if ((player.Equipment == null) || (player.Equipment.Armor == null))
                            {
                                Console.WriteLine($"{player.Name} has no armor and takes {damage} hit points of damage.");
                                player.TakeDamage(damage);
                            }
                            else
                            {
                                // TODO need a better way to navigate items in a list.  
                                // This works but I don't like it.
                                // Talk with instructor
                                if (damage > player.Equipment.Armor.Protection)
                                {
                                    int dmg1 = damage - player.Equipment.Armor.Protection;
                                    Console.WriteLine($"{player.Name}'s armor absorbes most of the attack and takes {dmg1} hit points of damage.");
                                    player.Equipment.ArmorTakeDamage(dmg1);
                                }
                                else
                                {
                                    Console.WriteLine($"{player.Name}'s armor absorbes all of the attack and takes no damage.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
