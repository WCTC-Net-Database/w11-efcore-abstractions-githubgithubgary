namespace ConsoleRpgEntities.Models.Item
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ItemType { get; set; }
        public int HitPoints { get; set; }

    }


}