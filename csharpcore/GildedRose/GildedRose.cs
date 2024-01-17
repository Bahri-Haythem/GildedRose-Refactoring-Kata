using System.Collections.Generic;

namespace GildedRoseKata;

public interface IStrategy
{
    void Update(Item item);
}

class Context
{
    private IStrategy _strategy;
    public Context()
    {
    }
    public Context setStrategy(IStrategy strategy)
    {
        _strategy = strategy;
        return this;
    }
    public void UpdateItem(Item item)
    {
        _strategy.Update(item);
    }
}
public class BrieUpdater : IStrategy
{
    public void Update(Item item)
    {
        item.SellIn--;
        if (item.Quality + 2 <= 50 && item.SellIn < 0)
            item.Quality += 2;
        else if (item.Quality < 50)
            item.Quality++;
    }
}

public class SulfurasUpdater : IStrategy
{
    public void Update(Item item)
    {
    }
}

public class ConcertUpdater : IStrategy
{
    public void Update(Item item)
    {
        item.SellIn--;
        if (item.SellIn < 0)
            item.Quality = 0;
        else if (item.SellIn < 5 && item.Quality + 3 <= 50)
            item.Quality += 3;
        else if (item.SellIn < 10 && item.Quality + 2 <= 50)
            item.Quality += 2;
        else if (item.Quality < 50)
            item.Quality++;
    }
}
public class OtherGoodsUpdater : IStrategy
{
    public void Update(Item item)
    {
        item.SellIn--;
        if (item.SellIn < 0 && item.Quality >= 2)
            item.Quality -= 2;
        else if (item.Quality > 0)
            item.Quality--;
    }
}

public class ConjuredUpdater : IStrategy
{
    public void Update(Item item)
    {
        if (item.Quality >= 2)
            item.Quality -= 2;
        else
            item.Quality = 0;
        item.SellIn--;
    }
}

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }
    private void UpdateItem(Item item)
    {
        var context = new Context();

        if (item.Name == "Sulfuras, Hand of Ragnaros")
            context.setStrategy(new SulfurasUpdater()).UpdateItem(item);
        else if (item.Name == "Aged Brie")
            context.setStrategy(new BrieUpdater()).UpdateItem(item);
        else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            context.setStrategy(new ConcertUpdater()).UpdateItem(item);
        else if (item.Name == "Conjured Mana Cake")
            context.setStrategy(new ConjuredUpdater()).UpdateItem(item);
        else
            context.setStrategy(new OtherGoodsUpdater()).UpdateItem(item);
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            UpdateItem(_items[i]);
        }
    }
}