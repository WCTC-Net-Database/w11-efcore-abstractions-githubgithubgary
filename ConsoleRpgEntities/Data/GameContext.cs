using ConsoleRpgEntities.Items;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Characters.Monsters;
using ConsoleRpgEntities.Models.Item;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpgEntities.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armor> Armors { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure TPH for Character hierarchy
            modelBuilder.Entity<Monster>()
                .HasDiscriminator<string>(m=> m.MonsterType)
                .HasValue<Goblin>("Goblin");

            // Configure TPH for Ability hierarchy
            modelBuilder.Entity<Ability>()
                .HasDiscriminator<string>(pa=>pa.AbilityType)
                .HasValue<ShoveAbility>("ShoveAbility");

            // Configure many-to-many relationship
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Abilities)
                .WithMany(a => a.Players)
                .UsingEntity(j => j.ToTable("PlayerAbilities"));

            modelBuilder.Entity<Item>()
                .HasDiscriminator<string>(I => I.ItemType)
                .HasValue<Weapon>("Weapon")
                .HasValue<Armor>("Armor");

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Equipment)
                .WithOne(p => p.Player)
                .HasForeignKey<Equipment>(p => p.PlayerID);

            base.OnModelCreating(modelBuilder);
        }

    }
}


