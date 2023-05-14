//Klass för alla rum i spelet, ärver av gameobject.
public class Room : GameObject {
	public List<string> ?Exits {get; set; }
	public List<Furniture> ?Furnitures {get; set; }
	public List<Item> ?Items {get; set; }

	//tom konstruktor så json kan deserialiseras.
	public Room() 
	{
	}

	public Room(int id, string name, string description) : base(id,name,description)
	{
		Exits = new List<string>();
		Furnitures = new List<Furniture>();
		Items = new List<Item>();
	}

	//Om man använder take på ett item i rummet försvinner det ur listan.
	public void removeFromItems(Item item)
	{
		Items.Remove(item);
	}

	//Om maan använder drop på ett item i spelarens inventory läggs det till i listan.
	public void addToItems(Item item)
	{
		Items.Add(item);
	}


	//En egen tostring som beskriver rummet
	public override string ToString()
	{
		string s = Description + "\n";

		//Kollar ifall det finns möbler/items i rummet och lägger till dem i rumsbeskrivningen.
		if(Furnitures.Count+Items.Count>0)
		{
			s = s + "You see:\n";

			foreach (Furniture furniture in Furnitures)
			{
				s = s + "\t" + furniture.ToString() + "\n";
			}

			foreach (Item item in Items)
			{
				s = s + "\t" + item.ToString() + "\n";
			}
		}
		
		return s;
	}
	
}