using System;
using System.Collections.Generic;


namespace DND5E_Battle_Sim
{
    public abstract class PlayerClassCreator
    {
        public abstract PlayerClass CreatePlayerClass();
    }

    public class PlayerClass
    {
        public string name;
        public int hitDice;
        public List<ArmorCategories> armorCategoryProficiencies;
        public List<WeaponCategories> weaponCategoryProficiencies;
        public List<WeaponTypes> weaponProficiencies;
        public List<Stats> savingThrows;
        public List<Skills> skillProficiencyOptions;
        public int skillProficiencyNumberOfChoices;
        public List<string> items;
        public List<List<List<string>>> equipmentOptions;
        public Dictionary<int, List<string>> feats;
        public int subClassLevel;
        public List<string> subClasses;

        public List<Stats> statRelevanceInOrder;

        public virtual void AssignToCharacter(Creature creature, int level)
        {
            //Debug.WriteLine(string.Format("Assigning {0} class", name));
            creature.baseStats.hitDiceNumber = level;
            creature.baseStats.hitDie = hitDice;
            foreach(ArmorCategories ac in armorCategoryProficiencies)
            {
                if (!creature.baseStats.armorCategoryProficiencies.Contains(ac))
                {
                    creature.baseStats.armorCategoryProficiencies.Add(ac);
                }
            }
            foreach (WeaponCategories wc in weaponCategoryProficiencies)
            {
                if (!creature.baseStats.weaponCategoryProficiencies.Contains(wc))
                {
                    creature.baseStats.weaponCategoryProficiencies.Add(wc);
                }
            }
            foreach (WeaponTypes wc in weaponProficiencies)
            {
                if (!creature.baseStats.weaponTypeProficiencies.Contains(wc))
                {
                    creature.baseStats.weaponTypeProficiencies.Add(wc);
                }
            }
            creature.baseStats.savingThrows = new List<Stats>(savingThrows);

            for (int i = 0; i <skillProficiencyNumberOfChoices; i++)
            {
                creature.skillChoices.Add(new List<Skills>(skillProficiencyOptions));
            }
            creature.itemChoices.AddRange(equipmentOptions);

            for (int l = 0; l <= level; l++)
            {
                if (feats.ContainsKey(l))
                {
                    foreach (string fc in feats[l])
                    {
                        //Debug.WriteLine(string.Format("Assigning feat {0}", fc));
                        creature.AddFeat(DnDManager.feats[fc].CreateFeat());
                    }
                }
            }

            foreach (String item in items)
            {
                creature.inventory.AddItem(DnDManager.items[item].CreateItem());
            }
        }

        public virtual void AssignMultiClassToCharacter(Creature creature, int level)
        {

        }
    }
}