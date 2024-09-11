using GildedRoseKata;
using GildedRoseKata.Interfaces;
using System.Collections.Generic;

namespace GildedRoseTests
{
    public class ItemRepositoryForTest : IItemRepository
    {
        private readonly IList<Item> _items;

        public ItemRepositoryForTest(IList<Item> items) 
        {
            _items = items; 
        }

        public IList<Item> GetItems()
        {
            return _items; 
        }
    }
}
