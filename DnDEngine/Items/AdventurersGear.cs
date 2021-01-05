namespace DND5E_Battle_Sim
{ 
    public abstract class AdventurersGear : Item
    {
        public AdventurersGear() : base()
        {
            itemType = ItemType.AdventuringGear.ToString();
        }
    }
}