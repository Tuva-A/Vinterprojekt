
bool loadGame = false;

//Kollar om det finns en savefil
if (File.Exists("save\\save.json"))
{
	Console.ForegroundColor = ConsoleColor.Cyan;
	Console.WriteLine("A saved game exist, do you want to continue from save file?");

	string answer = "";

	//Fråga tills spelaren ger svaret 'yes' eller 'no'
	while(!(answer == "yes" || answer == "no"))
	{
		Console.WriteLine("Answer 'yes' or 'no': ");
		answer = Console.ReadLine();
	}

	if(answer == "yes")
	{
		loadGame = true;
	}
	else if(answer == "no")
	{
		loadGame = false;
	}
}

// Deklarerar spelmotorn
GameEngine myMurderMysteryGame;

//laddar spel, annars skapar nytt
if(loadGame)
{
	myMurderMysteryGame = GameEngine.load();
}
else
{
	Console.ForegroundColor = ConsoleColor.Cyan;
	Console.WriteLine("Starting new game");

	myMurderMysteryGame=new GameEngine();

	//ifall något knasar i init så avbryts koden (init skulle ha mer saker från början men hann inte så den här koden är egentlig onödig just nu).
	if(!myMurderMysteryGame.init())
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("Could not initialize GameEngine, aborting.");
		Environment.Exit(1);
	}

	myMurderMysteryGame.newGame();
}

//Skriver ut intro till spelet
myMurderMysteryGame.intro();

//Huvudloopen - körs tills spelet är slut (slutas vid vinst/förlust/slut på ticks).
while(myMurderMysteryGame.tick());

//Spelet avslutas
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Bye.");
Console.ReadLine();