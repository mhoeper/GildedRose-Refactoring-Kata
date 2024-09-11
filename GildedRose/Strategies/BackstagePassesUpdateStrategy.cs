namespace GildedRoseKata.Strategies
{
    public class BackstagePassesUpdateStrategy: BaseUpdateStrategy
    {
        protected override int GetQuantityChange(Item item)
        {
            return item.SellIn switch
            {
                < 0 => -item.Quality,
                < 5 => 3,
                < 10 => 2,
                _ => 1
            };
        }
    }
}
