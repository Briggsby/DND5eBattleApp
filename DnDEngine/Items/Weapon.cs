using System;
using System.Collections.Generic;


namespace DND5E_Battle_Sim
{

    public enum WeaponCategories { None, SimpleWeapon, MartialWeapon, NaturalWeapon, Shields }
    public enum WeaponTypes { None, Shield, Scimitar, Shortbow, Club, Dagger, Shortsword, Battleaxe, Handaxe, LightHammer, Warhammer, Greataxe, Javelin, Rapier, Longsword, Mace, LightCrossbow };
    public enum WeaponProperty { Ammunition, Finesse, Heavy, Light, Loading, Range, Reach, Special, Thrown, TwoHanded, Versatile, Improvised, Silvered, SpecialLance, SpecialNet }

    public enum WeaponChoices { SimpleWeapon, MartialWeapon, MartialMeleeWeapon }

    public class Weapon : Item
    {
        public WeaponCategories weaponCategory;
        public WeaponTypes weaponType;
        public List<int> damageDice;
        public List<int> versatileDamageDice = new List<int>();
        public List<int> damageDiceNumber;
        public List<string> damageTypes;
        public Stats abilityStat;
        public int minRange;
        public int maxRange;
        public List<WeaponProperty> weaponProperties;
        public int acBonus;

        public Type ammunition = typeof(Arrow);
        public bool loadingAttackedThisTurn = false;

        public int attackBonus = 0;
        public int damageBonus = 0;

        public Weapon()
        {
            itemType = ItemType.Weapon.ToString();

            name = "Unarmed Strike";
            weaponType = WeaponTypes.None;
            weaponCategory = WeaponCategories.None;
            damageDice = new List<int>() { 1 };
            damageDiceNumber = new List<int>() { 1 };
            damageTypes = new List<string>() { DamageTypes.Bludgeoning.ToString() };
            abilityStat = Stats.Strength;
            minRange = 5;
            maxRange = 5;
            weaponProperties = new List<WeaponProperty>() { WeaponProperty.Light };
            acBonus = 0;
        }

        public override bool Equippable(Creature creature)
        {
            if (creature.weaponCategoryProficiencies.Contains(weaponCategory) || creature.weaponTypeProficiencies.Contains(weaponType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Equip(Creature creature, bool offHand = false)
        {

            if (weaponProperties.Contains(WeaponProperty.Light) && creature.weaponMainHand != null && creature.weaponMainHand.weaponProperties.Contains(WeaponProperty.Light))
            {
                offHand = true;
            }
            if (this is Shield)
            {
                offHand = true;
            }

            if (offHand)
            {
                if (creature.weaponOffHand != null)
                {
                    creature.weaponOffHand.UnEquip(creature);
                }
                creature.weaponOffHand = this;
            }
            else
            {
                if (creature.weaponMainHand != null)
                {
                    creature.weaponMainHand.UnEquip(creature);
                }
                creature.weaponMainHand = this;
                if (weaponProperties.Contains(WeaponProperty.TwoHanded))
                {
                    creature.weaponOffHand = null;
                }
            }

            base.Equip(creature);
        }

        public void GetDamageDice(Attack attack)
        {
            if (weaponProperties.Contains(WeaponProperty.Versatile) && equipper != null && equipper.weaponMainHand == this && equipper.weaponOffHand == null)
            {
                attack.damageDiceFaces = new List<int>(versatileDamageDice);
            }
            else
            {
                attack.damageDiceFaces = new List<int>(damageDice);
            }
            attack.damageDiceNumber = new List<int>(damageDiceNumber);
            attack.damageTypes = new List<string>(damageTypes);
        }

        public virtual void OnHit(Attack attack)
        {

        }
    }

    public abstract class WeaponCreator : ItemCreator
    {
        public virtual Weapon CreateWeapon()
        {
            return CreateItem() as Weapon;
        }
    }
}
