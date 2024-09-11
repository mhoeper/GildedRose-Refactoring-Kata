using System.Collections.Generic;

namespace GildedRoseKata.Interfaces
{
    public interface IItemRepository
    {
        IList<Item> GetItems();
    }
}
