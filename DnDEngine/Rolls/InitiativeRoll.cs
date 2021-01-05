namespace DND5E_Battle_Sim
{
    public class InitiativeRoll : Roll
    {
        public InitiativeRoll(Creature creature) : base(creature.encounter)
        {

        }
    }
}