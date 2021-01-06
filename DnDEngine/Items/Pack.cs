using System.Collections.Generic;


namespace DND5E_Battle_Sim
{
    public abstract class Pack : Item
    {
        public Dictionary<string, int> items;

        public void Unpack(Inventory inventory)
        {

        }
    }
}