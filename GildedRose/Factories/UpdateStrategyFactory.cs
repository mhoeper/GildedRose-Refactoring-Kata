using GildedRoseKata.Interfaces;
using GildedRoseKata.Strategies;

namespace GildedRoseKata.Factories
{
    public class UpdateStrategyFactory
    {
        public IUpdateStrategy Create(string name)
        {
            return name switch
            {
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassesUpdateStrategy(),
                "Aged Brie" => new AgedBrieUpdateStrategy(),
                "Sulfuras, Hand of Ragnaros" => new SulfurasUpdateStrategy(),
                "Conjured Mana Cake" => new ConjuredUpdateStrategy(),
                _ => new BaseUpdateStrategy(),
            };
        }
    }
}
