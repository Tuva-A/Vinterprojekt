//Klass för alla saker i spelet, ärver av GameObject
public class Item : GameObject {
	public int Weight {get; set; }
	public string ExamineText {get; set; }

	//tom konstruktor så json kan deserialiseras.
	public Item()
	{
	}

	public Item(int id, string name, string description, int weight,string examineText) : base(id,name,description)
	{
		Weight = weight;
		ExamineText = examineText;
	}

	//När man skriver ut ett item i rumsbeskrivning så får dess namn (look kommer visa desc, examine kommer visa examine text)
	public override string ToString()
	{
		return Name;
	}
}
