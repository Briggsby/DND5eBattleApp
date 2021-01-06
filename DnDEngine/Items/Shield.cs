using System.Collections.Generic;


namespace DND5E_Battle_Sim
{
    public class Shield : Weapon
    {
        public Shield() : base()
        {
            name = "Shield";
            weaponType = WeaponTypes.Shield;
            weaponCategory = WeaponCategories.Shields;
            damageDice = new List<int>() { 0 };
            damageDiceNumber = new List<int>() { 0 };
            damageTypes = new List<string>() { };
            abilityStat = Stats.Strength;
            minRange = 0;
            maxRange = 0;
            weaponProperties = new List<WeaponProperty>() { };
            acBonus = 2;
        }

        public override bool Equippable(Creature creature)
        {
            if (creature.weaponMainHand != null && creature.weaponMainHand.weaponProperties.Contains(WeaponProperty.TwoHanded))
            {
                return false;
            }
            return base.Equippable(creature);
        }
    }
}