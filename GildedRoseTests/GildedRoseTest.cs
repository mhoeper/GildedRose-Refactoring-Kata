using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseKata.Factories;
using GildedRoseKata.Repositories;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private GildedRose CreateGildedRose(IList<Item> items)
    {
        var factory = new UpdateStrategyFactory();
        var repository = new ItemRepositoryForTest(items); 
        return new GildedRose(factory, repository); 
    }

    [Fact]
    public void UpdateQuality_TestName()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = CreateGildedRose(items);
        app.UpdateQuality();
        Assert.Equal("foo", items[0].Name);
    }

    [Fact]
    public void UpdateQuality_NormalItem_DecreasesQualityAndSellIn()
    {
        var items = new List<Item> { new Item { Name = "Normal Item", 
            SellIn = 10, Quality = 20 } };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(19, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrie_IncreasesQuality()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", 
            SellIn = 10, Quality = 20 } };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(21, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_IncreasesQuality()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 11, Quality = 20 } };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(10, items[0].SellIn);
        Assert.Equal(21, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_IncreasesQualityBy2_WhenSellInLessThan11()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 10, Quality = 20 } };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(22, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_IncreasesQualityBy3_WhenSellInLessThan6()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 5, Quality = 20 } };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(23, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_DropsToZeroQuality_AfterConcert()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 0, Quality = 20 } };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_Sulfuras_DoesNotChange()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros",
            SellIn = 10, Quality = 80 } };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(10, items[0].SellIn);
        Assert.Equal(80, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_NormalItem_DecreasesQualityTwiceAsFast_AfterSellInDate()
    {
        var items = new List<Item> { new Item { Name = "Normal Item",
            SellIn = 0, Quality = 20 } };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(18, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrie_IncreasesQualityTwiceAsFast_AfterSellInDate()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie",
            SellIn = 0, Quality = 20 } };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(22, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_QualityNeverExceeds50()
    {
        var items = new List<Item> { 
            new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 },
        };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(50, items[0].Quality);

        Assert.Equal(9, items[1].SellIn);
        Assert.Equal(50, items[1].Quality);
    }

    [Fact]
    public void UpdateQuality_QualityNeverNegative()
    {
        var items = new List<Item> {
            new Item { Name = "Normal Item", SellIn = 10, Quality = 0 }
        };
        var app = CreateGildedRose(items);

        app.UpdateQuality();

        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }
}