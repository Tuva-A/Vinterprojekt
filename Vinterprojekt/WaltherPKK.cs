//Enda actionitem i spelet just nu
public class WaltherPKK : ActionItem {
	public int Bullets { get; set; }
	
	public WaltherPKK(int id,string name,string description,int weight,string examineText) : base(id,name,description,weight,examineText)
	{
		Bullets = 7;
		ExamineText = "The gun seems to have been used recently. There are " + Bullets + " bullets left";
	}

	public override bool action()
	{
		//TODO: Kod för att använda waltherpkk, går inte att skjuta någon just nu :(((

		if(Bullets>0)
		{
			Bullets--;
			ExamineText = "The gun seems to have been used recently. There are " + Bullets + " bullets left";
			
		}
		else
		{
			ExamineText = "You are out of bullets!";
		}
		
		return true;
	}
}