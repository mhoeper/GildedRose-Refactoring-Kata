using GildedRoseKata.Factories;
using GildedRoseKata.Interfaces;
using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    private readonly UpdateStrategyFactory _factory;

    public GildedRose(UpdateStrategyFactory factory, IItemRepository repository)
    {
        _factory = factory;
        Items = repository.GetItems();
    }

    public void UpdateQuality()
    {
        foreach (var v in Items)
        {
            var updateStrategy = _factory.Create(v.Name);
            updateStrategy.Update(v); 
        }
    }

    public void PrintDayInformation(int day)
    {
        Console.WriteLine("-------- day " + day + " --------");
        Console.WriteLine("name, sellIn, quality");
        for (var j = 0; j < Items.Count; j++)
        {
            Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
        }
        Console.WriteLine("");
    }
}