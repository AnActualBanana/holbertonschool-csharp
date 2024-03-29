using System.Collections.Generic;
using System.Collections;
using System;

abstract class Base
{
    /// <summary>
    /// base class
    /// </summary>
    public string name = "";
    public override string ToString()
    {
    return String.Format("{0} is a {1}", name, this.GetType().Name);
    }
}

interface IInteractive
{
    void Interact();
}

interface IBreakable
{
    int durability { get; set; }
    void Break();
}

interface ICollectable
{
    bool isCollected { get; set; }
    void Collect();
}
/// <summary>
/// Door
/// </summary>
class Door : Base, IInteractive
{
    public void Interact()
    {
        Console.WriteLine("You try to open the {0}. It's locked.", this.name);
    }

    public Door(string n = "Door")
    {
        this.name = n;
    }
}

class Decoration : Base, IInteractive, IBreakable
{
    public bool isQuestItem;
    public int durability { get; set; }
    public Decoration(string name ="Decoration", int durability = 1, bool isQuestItem = false)
    {
        if (durability < 1)
        {
            Console.WriteLine("Durability must be greater than 0");
        }
        this.name = name;
        this.durability = durability;
        this.isQuestItem = isQuestItem;
    }

    public void Interact()
    {
        if (durability < 1)
        {
            Console.WriteLine("The {0} has been broken.", this.name);
        }
        else if (isQuestItem)
        {
            Console.WriteLine("You look at the {0}. There's a key inside.", this.name);
        }
        else
        {
            Console.WriteLine("You look at the {0}. Not much to see here.", this.name);
        }
    }
    public void Break()
    {
        this.durability--;
        if (durability < 0)
        {
            Console.WriteLine("The {0} is already broken.", this.name);
        }

        if (durability > 0)
        {
            Console.WriteLine("You hit the {0}. It cracks.", this.name);
        }
        if (durability == 0)
        {
            Console.WriteLine("You smash the {0}. What a mess.", this.name);
        }
    }
}
/// <summary>
/// Key
/// </summary>
class Key : Base, ICollectable
{
    public bool isCollected { get; set; }
    public Key(string name = "Key", bool isCollected = false)
    {
        this.name = name;
        this.isCollected = isCollected;
    }

    public void Collect()
    {
        if (isCollected)
        {
            Console.WriteLine("You have already picked up the {0}.", this.name);
        }
        else
        {
            this.isCollected = true;
            Console.WriteLine("You pick up the {0}.", this.name);
        }
    }
}
/// <summary>
/// Objects
/// </summary>
class Objs<T> : IEnumerable<T>
{
	List<T> objects = new List<T>();

	public void Add(T obj)
	{
		objects.Add(obj);
	}

	public IEnumerator<T> GetEnumerator()
	{
		foreach (T item in objects)
		{
			yield return item;
		}
	}
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}
