using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<InventoryItem> items = new List<InventoryItem>();

        items.Add(new Sword());
        items.Add(new Rope());
        items.Add(new Water());
        items.Add(new Food());
        items.Add(new Bow());
        items.Add(new Arrow());

        foreach (var item in items)
        {
            Console.WriteLine(item.Display());
        }
    }
}

public abstract class InventoryItem
{
    public abstract string Display();
}

public class Sword : InventoryItem
{
    public override string Display()
    {
        return "Sword: A sharp weapon used for combat.";
    }
}

public class Rope : InventoryItem
{
    public override string Display()
    {
        return "Rope: A strong and durable rope for various purposes.";
    }
}

public class Water : InventoryItem
{
    public override string Display()
    {
        return "Water: A bottle of clean drinking water.";
    }
}

public class Food : InventoryItem
{
    public override string Display()
    {
        return "Food: A delicious and nutritious meal.";
    }
}

public class Bow : InventoryItem
{
    public override string Display()
    {
        return "Bow: A weapon used for archery.";
    }
}

public class Arrow : InventoryItem
{
    public override string Display()
    {
        return "Arrow: A projectile shot from a bow.";
    }
}
