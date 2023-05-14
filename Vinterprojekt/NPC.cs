//Klass för alla npc:er, ärver från person. 
public class NPC : Person {
	//när en npc kommer till sitt favoritrum, stannar den där.
	public string FavoriteRoom { get; set; }
	public bool IsTheKiller {get; set; }

	//har några fraser som visas när man använder talk "npc.name".
	public List<string> Phrases {get; set; } 

	//tom konstruktor så json kan deserialiseras.
	public NPC()
	{
	}

	public NPC(int id, string name, string descsription, int strength, int weight,string favoriteRoom,bool isTheKiller, List<string> phrases,bool isDead) : base(id,name,descsription,strength,weight,favoriteRoom,isDead)
	{
		FavoriteRoom = favoriteRoom;
		IsTheKiller = isTheKiller;
		Phrases = phrases;
	}

	//flyttar npc:n slumpmässigt mellan rummen.
	public bool move(GameEngine gameEngine)
	{
		//Om npc:n är död flyttar den inte rum
		if(IsDead)
		{
			return true;
		}

		//Om npc:n är i sitt favvorum så stannar den där
		if(CurrentRoom == FavoriteRoom)
		{
			return true;
		}

		//Npc:n är varken död eller i sitt favvorum så flyttar den slumpmässigt
		Random rand = new Random();
		//Fattar inte riktigt denna fick hjälp av farsan.
		List<string> possibleExits = gameEngine.Rooms.ElementAt(gameEngine.getRoomsIndex(CurrentRoom)).Exits;
		string newRoom = possibleExits.ElementAt(rand.Next(possibleExits.Count));

		//Kollar ifall rummet är ett specialrum t.ex "hidden", de står efter : i rumsnamnet från exits.
		if(newRoom.Contains(":"))
		{
			newRoom = newRoom.Split(":")[1];
		}

		//npc:erna kan inte gå ut.
		if(newRoom == "outside")
		{
			//Console.WriteLine(Name + " tried to move outside but an invisible force kept them inside the house");
			return true;
		}
		//för att kolla hur de förflyttar sig i testkörningarna
		//Console.WriteLine(Name + " is moving from "+ Room + " to "+ newRoom);

		//Uppdaterar npc:ns befintliga rum med det nya slumpade rummet
		CurrentRoom = newRoom;

		return true;
	}

	//metod som slumpar en fras från fraser när man skriver talk npc.name
	public void talk(GameEngine gameEngine)
	{
		Console.ForegroundColor = ConsoleColor.DarkMagenta;

		if(IsDead)
		{
			Console.WriteLine("The silence from a dead "+Name+ " is deafening");
		}
		else if (!(CurrentRoom == gameEngine.ThePlayer.CurrentRoom))
		{
			Console.WriteLine("Can not see " + Name + " in " + gameEngine.ThePlayer.CurrentRoom);
		}
		else
		{
			Console.Write(Name + " says: ");

			Random rand = new Random();
			int phraseToUse;

			if(IsTheKiller)
			{
				//om man pratar med mördare är första frasen från listan med i slumpen.
				phraseToUse = rand.Next(0,Phrases.Count);
			}
			else
			{
				//men om man inte pratar med mördaren är första frasen inte med.
				phraseToUse = rand.Next(1,Phrases.Count);
			}

			Console.WriteLine(Phrases.ElementAt(phraseToUse));
		}
	}
}