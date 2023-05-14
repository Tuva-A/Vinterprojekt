//Subklass till item men huvudklass för alla items som går att använda (endast WaltherPKK just nu).
public abstract class ActionItem : Item {
	public ActionItem(int id,string name,string description,int weight,string examineText) : base(id,name,description,weight,examineText)
	{
	}
	
	//Tvingar alla actionitems att ha egen kod för sin action
	public abstract bool action(); 
}
