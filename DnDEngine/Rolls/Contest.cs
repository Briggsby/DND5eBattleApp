namespace DND5E_Battle_Sim
{
    public class Contest : Roll
    {
        public Contest(Skills skill, Creature initiator, Creature defender) : base(initiator.encounter)
        {

        }
    }
}