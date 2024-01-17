using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            if (_items[i].Name == "Sulfuras, Hand of Ragnaros")
                continue;

            if (_items[i].Name != "Aged Brie"
                && _items[i].Name != "Backstage passes to a TAFKAL80ETC concert"
                && _items[i].Quality > 0)
            {
                _items[i].Quality--;
            }
            else if (_items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (_items[i].SellIn <= 5 && _items[i].Quality + 2 < 50)
                {
                    _items[i].Quality += 3;
                }
                else if (_items[i].SellIn <= 10 && _items[i].Quality + 1 < 50)
                {
                    _items[i].Quality += 2;
                }
                else if (_items[i].Quality < 50)
                {
                    _items[i].Quality++;
                }
            }
            else if (_items[i].Quality < 50)
            {
                _items[i].Quality++;
            }

            _items[i].SellIn--;

            if (_items[i].SellIn < 0)
            {
                if (_items[i].Name == "Aged Brie" && _items[i].Quality < 50)
                {
                    _items[i].Quality++;
                }
                else if (_items[i].Name != "Backstage passes to a TAFKAL80ETC concert"
                    && _items[i].Name != "Aged Brie"
                    && _items[i].Quality > 0)
                {
                    _items[i].Quality--;
                }
                else if (/*_items[i].Name != "Aged Brie"*/
                    _items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    _items[i].Quality = 0;
                }
            }
        }
    }
}