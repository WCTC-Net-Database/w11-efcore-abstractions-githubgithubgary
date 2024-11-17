namespace ConsoleRpgEntities.Models.Item
{
    public interface IItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ItemType { get; set; }
        public int HitPoints { get; set; }

        // Would eventually implement something that lets the Item health per round
        void Heal(int hitpoints);

        // TODO
        // Did not use this but could if the item was say a treasure chest in a room
        // But don't think this is the best place. Should be someplace else so that 
        // We can have many treasure chests to damage.  This would impact the master
        // Version of the chest.
        // Talk with instructor about a better way
        void TakeDamage(int hitpoints);
    }

}