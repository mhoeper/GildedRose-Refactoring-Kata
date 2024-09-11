namespace GildedRoseKata.Strategies
{
    public class AgedBrieUpdateStrategy: BaseUpdateStrategy
    {
        protected override int GetQuantityChange(Item item)
        {
            return 1;
        }
    }
}
