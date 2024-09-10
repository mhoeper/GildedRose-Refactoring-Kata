using GildedRoseKata.Interfaces;
using System;

namespace GildedRoseKata.Strategies
{
    public class BaseUpdateStrategy : IUpdateStrategy
    {
        protected virtual int GetQuantityChange(Item item)
        {
            return -1; 
        }

        public void Update(Item item)
        {
            item.SellIn--;
            item.Quality += GetQuantityChange(item);
            if (item.SellIn < 0)
            {
                item.Quality += GetQuantityChange(item);
            }
            if (item.Quality > 50)
            {
                item.Quality = 50; 
            }
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
