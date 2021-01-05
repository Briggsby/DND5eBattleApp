namespace DND5E_Battle_Sim
{ 
    public abstract class WondrousItem : Item
    {
        public WondrousItem() : base()
        {
            itemType = ItemType.WondrousItem.ToString();
        }
    }
}