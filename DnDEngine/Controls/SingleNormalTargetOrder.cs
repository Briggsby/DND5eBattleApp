namespace DND5E_Battle_Sim
{
    public class SingleNormalTargetOrder : Control
    {
        Object controlObject;
        Creature creature;

        public SingleNormalTargetOrder(Creature creature, Object controlObject, int range, Color? color = null)
        {
            this.creature = creature;
            this.controlObject = controlObject;
            EngManager.StartCoroutine(SetOrderControl(creature.encounter.board, creature.boardTile, range, color ?? Color.OrangeRed, new List<TileOrderCriteria>() { TileOrderCriteria.WithCreature }));
        }

        public override void SelectionMade()
        {
            base.SelectionMade();
            if (controlObject is Feat)
            {
                (controlObject as Feat).SelectionMadeOrder(this);
            }
        }

    }
}