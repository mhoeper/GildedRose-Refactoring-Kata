using GildedRoseKata.Factories;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var updateStrategy = UpdateStrategyFactory.Create(Items[i].Name);
            updateStrategy.Update(Items[i]); 
        }
    }
}