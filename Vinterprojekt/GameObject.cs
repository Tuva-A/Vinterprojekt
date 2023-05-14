//Alla objekt i spelet ska vara av typen GameObject(huvudklassen).
public abstract class GameObject {
	public int	   ?Id {get; set; }
	public string	?Name {get; set; }
	public string	?Description {get; set; }

	//tom konstruktor så json kan deserialiseras.
	public GameObject()
	{
	}
	
	public GameObject(int id,string name,string description)
	{
		Id = id;
		Name = name;
		Description = description;
	}
}