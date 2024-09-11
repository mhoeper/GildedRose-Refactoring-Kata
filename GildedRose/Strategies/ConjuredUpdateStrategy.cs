namespace GildedRoseKata.Strategies
{
    public class ConjuredUpdateStrategy: BaseUpdateStrategy
    {
        protected override int GetQuantityChange(Item item)
        {
            return -2;
        }
    }
}
