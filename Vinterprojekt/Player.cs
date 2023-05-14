//Klass för spelaren,ärver från person,bestäms i newgame.
public class Player : Person {
	//tom konstruktor så json kan deserialiseras.
	public Player()
	{
	}

	public Player(int id, string name, string description, int strength, int weight,string room,bool isDead) : base(id,name,description,strength,weight,room,isDead)
	{
	}
}
