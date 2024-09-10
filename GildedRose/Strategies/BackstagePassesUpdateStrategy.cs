namespace GildedRoseKata.Strategies
{
    public class BackstagePassesUpdateStrategy: BaseUpdateStrategy
    {
        protected override int GetQuantityChange(Item item)
        {
            if (item.SellIn < 0)
            {
                return -item.Quality;
            }
            if (item.SellIn < 5)
            {
                return 3;
            }
            if (item.SellIn < 10)
            {
                return 2;
            }
            return 1;
        }
    }
}
