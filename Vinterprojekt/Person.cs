//abstrakt huvudklass för npcs och spelaren. Ärver av gameobject.
public abstract class Person : GameObject {
	public int Strength {get; set; }
	public int Weight {get; set; }
	public string CurrentRoom {get; set; }

	public bool IsDead {get; set; }
	public List<Item> ?Inventory {get; set; }

	//tom konstruktor så json kan deserialiseras.
	public Person() 
	{
	}

	public Person(int id, string name, string description, int strength, int weight,string room,bool isDead) : base(id,name,description)
	{
		Strength = strength;
		Weight = weight;
		CurrentRoom = room;
		Inventory = new List<Item>();
		IsDead = isDead;
	}

	// Skriver ut allt du har i ditt inventory. 
	public void showInventory()
	{
		Console.ForegroundColor = ConsoleColor.DarkMagenta;
		Console.WriteLine("I look in my pockets and find:");

		if(Inventory.Count == 0)
		{
			Console.WriteLine("\tNothing!");
		}
		else
		{
			foreach(Item item in Inventory)
			{
				Console.WriteLine("\t"+item.ToString());
			}
		}	
	}

	//Lägger till item till inventory(när man använder take).
	public void addToInventory(Item item)
	{
		Inventory.Add(item);
	}

	// Tar bort item från inventory(när man använder drop).
	public void removeFromInventory(Item item)
	{
		Inventory.Remove(item);
	}

	// Räknar ut det samlade vikten av allt i iventoryt.
	public int inventoryWeight()
	{
		int totalWeight = 0;

		foreach(Item item in Inventory)
		{
			totalWeight += item.Weight;
		}

		return totalWeight;
	}
}