namespace DND5E_Battle_Sim
{
    public class MoveOrder : Control
    {
        Creature creature;

        public MoveOrder(Creature creature)
        {
            this.creature = creature;
            EngManager.StartCoroutine(SetOrderControl(creature.encounter.board, creature.boardTile, creature.MoveSpeedLeft, Color.Aqua, new List<TileOrderCriteria>() { TileOrderCriteria.WithoutCreature }));
        }

        public override void SelectionMade()
        {
            base.SelectionMade();
            EngManager.StartCoroutine(creature.MoveOrder(orderControl.selection));
        }
    }
}