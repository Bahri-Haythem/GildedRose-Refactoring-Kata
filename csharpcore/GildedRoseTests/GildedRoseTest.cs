using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void quality_is_less_than_50()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.LessOrEqual(items[0].Quality, 50);
    }

    [Test]
    public void quality_is_positive()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Greater(items[0].Quality, 0);
    }

    [Test]
    public void quality_Sulfuras_is_less_than_80()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.LessOrEqual(items[0].Quality, 80);
    }

    [Test]
    public void aged_brie_test()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -24, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.AreEqual(items[0].Quality, 50);
    }
}