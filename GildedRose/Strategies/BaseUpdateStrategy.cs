using GildedRoseKata.Interfaces;

namespace GildedRoseKata.Strategies
{
    public class BaseUpdateStrategy : IUpdateStrategy
    {
        private const int MinQuantity = 0;
        private const int MaxQuantity = 50; 

        protected virtual int GetQuantityChange(Item item)
        {
            return -1; 
        }

        private void EnsureQuantityLimits(Item item)
        {
            if (item.Quality > MaxQuantity)
            {
                item.Quality = MaxQuantity;
            }
            if (item.Quality < MinQuantity)
            {
                item.Quality = MinQuantity;
            }
        }

        public void Update(Item item)
        {
            item.SellIn--;
            item.Quality += GetQuantityChange(item);
            var isSellInDayReached = item.SellIn < 0;
            if (isSellInDayReached)
            {
                item.Quality += GetQuantityChange(item);
            }
            EnsureQuantityLimits(item); 
        }
    }
}
