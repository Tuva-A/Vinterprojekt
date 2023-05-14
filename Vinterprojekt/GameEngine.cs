using System.Text.Json;
using System.Collections;

//Klass för spelmotorn
public class GameEngine 
{
	public HashSet<string> Verbs { get; set; } // Hashset med alla verb som spelet tillåter, t.ex take, talk, drop osv...
		
	public int HelpCount { get; set; } // Hur många gånger man frågat om hjälp
	public int TickCount { get; set; } // Hur många ticks som körts, det går ett tick varje gång man klickar på enter.

	public List<Room> Rooms { get; set; } 
	public Dictionary<string,int> RoomsIndex { get; set; } // Ett index för att hitta rätt room i rooms.
	public List<NPC> Npcs {get; set; }
	
	public readonly int NO_TICKS = 40; //Antal ticks man kan köra innan game over

	public Player? ThePlayer { get; set; }
	
	public GameEngine()
	{
		Verbs=new HashSet<string>();
		Rooms = new List<Room>();
		Npcs = new List<NPC>();
		RoomsIndex = new Dictionary<string, int>();	
		HelpCount = 0;
	}

	//init körs när man startar nytt spel just nu är det bara tillåtna kommandon (verb).
	public bool init()
	{
		//Console.WriteLine("Init GameEngine");
		Verbs.Add("accuse");	//1 Klar
		Verbs.Add("close");	//2 Hann inte
		Verbs.Add("drop");	//2 Klar
		Verbs.Add("examine");	//2 Klar
		Verbs.Add("exits");	//1 Klar
		Verbs.Add("go");	//2 Klar
		Verbs.Add("help");	//1 Klar
		Verbs.Add("inventory");	//1 Klar
		Verbs.Add("load");	//1 Klar
		Verbs.Add("look");	//2 Klar
		Verbs.Add("open");	//2 Hann inte
		Verbs.Add("quit");	//1 Klar
		Verbs.Add("save");	//1 Klar
		Verbs.Add("take");	//2 Klar
		Verbs.Add("talk");	//2 Klar
		Verbs.Add("use");	//2 Hann inte
		Verbs.Add("xyzzy");	//1 Klar
		Verbs.Add("shoot");     //2 Hann inte
		
		return true;
	}

	//skapar ett nytt spel via newgame.
	public bool newGame()
	{
		NewGame newGame = new NewGame(this); //Fick hjälp av farsan med att bryta ut koden från gameengine till newgame.
		newGame.populate();

		return true;
	}

	//Visar spelets introtext.
	public void intro()
	{
		centerWrite("Welcome to Murder Mystery");
		centerWrite("A game of skill and cunning!");
	}

	//skapar savefil i json när man skriver in save.
	public bool save()
	{
		Console.ForegroundColor = ConsoleColor.DarkMagenta;
		Console.Write("Saving game...");
		var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true , };

		string jsonString = JsonSerializer.Serialize(this,options);

		//Console.WriteLine(jsonString);

		System.IO.File.WriteAllText("save\\save.json",jsonString);

		Console.WriteLine("DONE");

		return true;
	}

	//Laddar (deserialiserar) en gameengine från json när man startar spelet eller skriver load.
	public static GameEngine load()
	{
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine("Loading game");

		string jsonString = File.ReadAllText("save\\save.json");

		var options = new JsonSerializerOptions { IncludeFields = true };

		return JsonSerializer.Deserialize<GameEngine>(jsonString,options);
	}

	//Skriver ut en string centrerat, men man måste fixa storleken på terminalen innan man laddar spelet annars kommer det inte centreras.
	public void centerWrite(string s)
	{
		Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
		Console.WriteLine(s);
	}

	//skapa index för ett rum.
	public void addRoomsIndex(string roomName,int index)
	{
		RoomsIndex.Add(roomName,index);
	}

	//hämta index för ett rum.
	public int getRoomsIndex(string roomName)
	{
		return RoomsIndex[roomName];
	}

	//här sker interaktionen med spelaren
	public bool tick()
	{
		//skriver ut rumsbeskrivning
		Room curRoom = Rooms.ElementAt(getRoomsIndex(ThePlayer.CurrentRoom));
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine("\n"+curRoom.ToString());

		//Flytta alla npc:er vid varje tick
		foreach(NPC curNPC in Npcs)
		{
			curNPC.move(this);

			if (curNPC.CurrentRoom == curRoom.Name)
			{
				Console.WriteLine(curNPC.Name +" is in the room.");
			}
		}

		//Här skriver spelaren in kommandon
		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("\n> ");
		Console.ForegroundColor = ConsoleColor.White;

		string? userCommand = Console.ReadLine();

		//Kontrollerar att spelaren skrivit in text.
		if(userCommand == null || userCommand == "")
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Empty input!");
			
			return true;
		}

		//Kontrollerar om det är slut på ticks.
		if(TickCount>NO_TICKS)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("");
			centerWrite("You are out of time. The murder has fled the");
			centerWrite(" country and you return to your home in shame.");
			Console.WriteLine("");
			Console.WriteLine("");
			centerWrite("G A M E   O V E R");
			return false;
		}

		//Delar upp användarens kommando i ord och lägger resultaten i en string array
		string[] commandTokens = userCommand.ToLower().Split(" ");
		string verb;
		string substantive;
		
		switch(commandTokens.Length)
		{
			case 1:	
				verb = commandTokens[0];
				if(Verbs.Contains(verb))
				{
					TickCount++;
					return action(verb);
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("I don't know how to " + verb);
				}
				break;

			case 2:
				verb = commandTokens[0];
				substantive = commandTokens[1];

				if(Verbs.Contains(verb))
				{
					TickCount++;
					return action(verb,substantive);
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("I don't know how to: "+userCommand);
				}
				break;

			default:
			//todo: lägga till stöd för fler än två ord i ett kommando t.ex look at something
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("I don't know how to: "+userCommand);
				break;
		}

		return true;
	}

	//Hantera kommandon med ett ord
	private bool action(string verb)
	{
		switch(verb)
		{
			case "exits":
				showExits();
				break;

			case "quit":
				return false;

			case "help":
				showHelp();
				break;

			case "inventory":
				ThePlayer.showInventory();
				break;

			case "load":
				load();
				break;

			case "save":
				save();
				break;

			case "accuse":
				accuse();
				return false; //Kan bara anklaga en gång sen är det game over.

			case "xyzzy":
				cheat();
				break;

			default:
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(verb + " needs more information");
				break;
		}		

		return true;
	}

	//Hantera kommandon med två ord
	private bool action(string verb,string substantive)
	{
		switch(verb)
		{
			case "go":
				changeRoom(substantive);
				break;

			case "take":
				take(substantive);
				break;

			case "drop":
				drop(substantive);
				break;

			case "examine":
				examine(substantive);
				break;

			case "look":
				lookAt(substantive);
				break;

			case "talk":
				talk(substantive);
				break;

			case "shoot":
				action(substantive);
				break;
		}

		return true;
	}

	
	//Metoder för actions:

	//om man skriver in den hemliga koden anropas cheat metoden.
	public void cheat()
	{
		Console.ForegroundColor = ConsoleColor.Magenta;
		Console.Write("Ha! You know the secret word! The killer is ");

		foreach(NPC curNPC in Npcs)
		{
			if(curNPC.IsTheKiller)
			{
				Console.WriteLine(curNPC.Name);
			}
		}
	}

	//om man skriver help anropas showHelp metoden.
	public void showHelp()
	{
		HelpCount++;

		if(HelpCount>1)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("You already asked for help - "+ randomInsult());
			return;
		}

		Console.ForegroundColor = ConsoleColor.DarkMagenta;
		Console.WriteLine("I understand the following verbs:\n");
		
		foreach(string verb in Verbs)
		{
			Console.Write(verb + " ");
		}
		
		Console.WriteLine("\n\n(And that's all the help you will get!)");
	}
	
	//visar alla möjliga utgångar från rummet man befinner sig i om man skriver exits.
	public void showExits()
	{
		Room curRoom = Rooms.ElementAt(getRoomsIndex(ThePlayer.CurrentRoom));
		
		Console.ForegroundColor = ConsoleColor.DarkMagenta;
		Console.WriteLine("You can go:");

		foreach(string exit in curRoom.Exits)
		{
			if(!exit.StartsWith("hidden:"))  //skriver inte ut gömda rum.
			{
				Console.WriteLine("\t"+exit);
			}
		}

		Console.WriteLine("");
	}

	// när man vet vem mördaren är skrivs accuse för att anropa metoden.
	public void accuse()
	{
		Console.ForegroundColor = ConsoleColor.DarkYellow;
		Console.WriteLine("So who do you think did this awful crime?");

		//kontrollera att användaren skriver in ett giltigt npc namn.
		bool done = false;
		string suspectName = "";
		NPC suspect = null;

		while(!done)
		{
			suspectName = Console.ReadLine();

			foreach(NPC curNPC in Npcs)
			{
				if(curNPC.Name.ToLower() == suspectName.ToLower())
				{
					suspect = curNPC;
					done = true;
				}
			}
			if (!done)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Sorry, but " + suspectName + " is not a part of this game.");
				Console.ForegroundColor = ConsoleColor.DarkYellow;
			}
		}

		//Kolla om spelaren har rätt.
		if(suspect.IsTheKiller)
		{
			//You win!
			centerWrite("You did it! We all know that " + suspect.Name + " was the killer!");
		}
		else
		{
			//You loose!
			centerWrite("You are completely useless. " + suspect.Name + " was not the killer!");
			centerWrite("You die a horrible death of shame!");
		}	
	}

	//När man skriver go anropas metoden changeRoom.
	public void changeRoom(string newRoom)
	{
		Room curRoom = Rooms.ElementAt(getRoomsIndex(ThePlayer.CurrentRoom));
		bool foundNewRoom = false;

		foreach(string exit in curRoom.Exits)
		{
			string theExit = exit;

			//om exit är gömd tar man bort "hidden:" från rumsnamnet.
			if(theExit.StartsWith("hidden:"))
			{
				theExit=theExit.Split(":")[1];
			}

			if(theExit == newRoom)
			{
				ThePlayer.CurrentRoom = newRoom;
				foundNewRoom = true;
			}
		}

		if(!foundNewRoom)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("You can not go to " + newRoom + ", it does not exist!");
		}
	}

	// om man skriver take anropas metoden take.
	public void take(string itemToTake)
	{
		Room curRoom = Rooms.ElementAt(getRoomsIndex(ThePlayer.CurrentRoom));
		bool found = false;
		Item ?itemTaken = null;

		//Kolla om spelaren försöker ta en npc - tyvärr inte tillåtet.
		foreach(NPC curNPC in Npcs)
		{
			if(curNPC.Name.ToLower() == itemToTake.ToLower())
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine("Sorry, "+curNPC.Name+" does not fit in your pocket!");
				return;
			}
		}

		//Kolla items i rummet du befinner dig.
		foreach(Item item in curRoom.Items)
		{
			if(item.Name.ToLower() == itemToTake.ToLower())
			{
				found = true;

				//kolla att spelaren har tillräckligt strenght för att plocka upp itemet.
				if(ThePlayer.inventoryWeight() + item.Weight < ThePlayer.Strength)
				{
					ThePlayer.addToInventory(item);
					itemTaken = item;
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.WriteLine("You took the " + item.Name + " and put it in your pocket");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("You are not strong enough!");
				}
			}
		}

		//om spelaren orkade ta upp itemet, ta bort det från rummets items.
		if(itemTaken != null)
		{
			curRoom.removeFromItems(itemTaken);
		}

		//spelaren skrev något som inte fanns.
		if(!found)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't see any " + itemToTake + " (" + randomInsult() + ")");
		}
	}

	//om man skriver drop anropas metoden drop.
	public void drop(string itemToDrop)
	{
		Room curRoom = Rooms.ElementAt(getRoomsIndex(ThePlayer.CurrentRoom));
		bool found = false;
		Item ?itemDropped = null;

		//kolla om itemet finns i spelarens inventory.
		foreach(Item item in ThePlayer.Inventory)
		{
			if(item.Name.ToLower() == itemToDrop.ToLower())
			{
				found = true;
				itemDropped = item;
			}
		}

		// och om det fanns så ta bort itemet från spelarens inventory och lägg till i rummets items.
		if(itemDropped != null)
		{
			ThePlayer.removeFromInventory(itemDropped);
			curRoom.addToItems(itemDropped);
		}
		
		//spelaren skrev något som inte fanns.
		if(!found)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't see any " + itemToDrop + " (" + randomInsult() + ")");
		}
	}

	//om man skriver examine anropas metoden examine.
	public void examine(string itemToExamine)
	{
		Room curRoom = Rooms.ElementAt(getRoomsIndex(ThePlayer.CurrentRoom));
		bool found = false;

		//kolla om föremålet finns i rummets items.
		foreach(Item item in curRoom.Items)
		{
			if(item.Name.ToLower() == itemToExamine.ToLower())
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine(item.ExamineText);
				found = true;
			}
		}

		//kolla om föremålet finns i rummets furnitures.
		foreach(Furniture furniture in curRoom.Furnitures)
		{
			if(furniture.Name.ToLower() == itemToExamine.ToLower())
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine(furniture.ExamineText);
				found = true;
			}
		}

		//kolla om npc finns i npcs.
		foreach(NPC curNPC in Npcs)
		{
			if(curNPC.Name.ToLower() == itemToExamine.ToLower())
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine("I beg your pardon! " + curNPC.Name + " does not like to be examined by you - creep!");
				found = true;
			}
		}

		//spelaren skrev in något föremål som inte fanns.
		if(!found)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't see any " + itemToExamine + " ("+randomInsult() + ")");
		}
	}

	//om man skriver look anropas metoden lookAt.
	public void lookAt(string itemToLookAt)
	{
		Room curRoom = Rooms.ElementAt(getRoomsIndex(ThePlayer.CurrentRoom));
		bool found = false;

		//kolla om föremålet finns i rummets items.
		foreach(Item item in curRoom.Items)
		{
			if(item.Name.ToLower() == itemToLookAt.ToLower())
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine(item.Description);
				found = true;
			}
		}

		//kolla om föremålet finns i rummets furnitures.
		foreach(Furniture furniture in curRoom.Furnitures)
		{
			if(furniture.Name.ToLower() == itemToLookAt.ToLower())
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine(furniture.Description);
				found = true;
			}
		}

		//kolla om npc finns i npcs.
		foreach(NPC curNPC in Npcs)
		{
			if(curNPC.Name.ToLower() == itemToLookAt.ToLower())
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine(curNPC.Description);
				found = true;
			}
		}

		//spelaren skrev in något föremål som inte fanns.
		if(!found)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't see any " + itemToLookAt + " (" + randomInsult() + ")");
		}
	}

	//om man skriver talk anropas metoden talk.
	public void talk(string who)
	{
		bool npcFound=false;

		//kolla om npc finns i npcs.
		foreach(NPC curNPC in Npcs)
		{
			if(curNPC.Name.ToLower() == who.ToLower())
			{
				curNPC.talk(this);
				npcFound = true;
			}
		}

		//spelaren skrev in någon npc som inte finns.
		if(!npcFound)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("You look hard for " + who + " but " + who + " is nowhere to be seen (" + randomInsult() + ")");
		}
	}


	//lista med random insults som ges ifall spelaren matar in help för ofta aka mer än en gång
	private string randomInsult()
	{
		Random rand = new Random();
		int number = rand.Next(10);

		switch(number)
		{
			case 0:
				return "I can explain it to you, but I can’t understand it for you";
			case 1:
				return "Perhaps your parents dropped you behind a wagon?";
			case 2:
				return "Calling you an idiot would be an insult to all the stupid people";
			case 3:
				return "It's better to let someone think you are an Idiot than to open your mouth and prove it";
			case 4:
				return "Some babies were dropped on their heads but you were clearly thrown at a wall";
			case 5:
				return "I guess you prove that even god makes mistakes sometimes";
			case 6:
				return "If I wanted to kill myself I'd climb your ego and jump to your IQ";
			case 7:
				return "You must have been born on a highway because that's where most accidents happen";
			case 8:
				return "Brains aren't everything. In your case they're nothing";
			case 9:
				return "I don't know what makes you so stupid, but it really works";
		}

		return "Yo mama!";
	}
}
