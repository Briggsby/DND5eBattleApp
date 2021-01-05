namespace DND5E_Battle_Sim
{ 
    public abstract class Tool : Item
    {
        public Tool() : base()
        {
            itemType = ItemType.Tools.ToString();
        }
    }
}