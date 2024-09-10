using GildedRoseKata.Interfaces;
using GildedRoseKata.Strategies;

namespace GildedRoseKata.Factories
{
    public static class UpdateStrategyFactory
    {
        public static IUpdateStrategy Create(string name)
        {
            switch (name)
            {
                case "Backstage passes to a TAFKAL80ETC concert": return new BackstagePassesUpdateStrategy();
                case "Aged Brie": return new AgedBrieUpdateStrategy();
                case "Sulfuras, Hand of Ragnaros": return new SulfurasUpdateStrategy();
                case "Conjured Mana Cake": return new ConjuredUpdateStrategy();
                default: return new BaseUpdateStrategy();
            }
        }
    }
}
