//Gör en random generator för att bestämma hur många som kan vara i ett rum samtidigt
Random generator = new Random(10);
int max = generator.Next();

//Skapa rum (lägger rummen i en lista)
List<Room> rooms = new List<Room>();
//public Room(string name,string description,int maxOccupants,string[] exits)
rooms.Add(new Room("Attic", "You are in a dark attic with lots of stuff.", 4, new string[] { "Staircase to Attic" }));
rooms.Add(new Room("Basement", "You are in a dusty basement. You can " +
"see mold in the corners. This is not a nice place to be",
7, new string[] { "Staircase to Basement" }));
rooms.Add(new Room("Basement", "desc", max, new string[] { "Staircase to Basement", "Laundry Room", "Storage Room", "Boiler Room" }));
rooms.Add(new Room("Boiler Room", "desc", max, new string[] { "Basement" }));
rooms.Add(new Room("Dining Hall", "desc", max, new string[] { "" }));
rooms.Add(new Room("Hallway", "desc", max, new string[] { "" }));
rooms.Add(new Room("Kitchen", "desc", max, new string[] { "" }));
rooms.Add(new Room("Laundry Room", "desc", max, new string[] { "Basement" }));
rooms.Add(new Room("Library", "desc", max, new string[] { "Staircase to Attic", "Bathroom", "Second Floor" }));
rooms.Add(new Room("Living Room", "desc", max, new string[] { "" }));
rooms.Add(new Room("Masters Bedroom", "desc", max, new string[] { "Second Floor", "Closet", "Masters Bedroom" }));
rooms.Add(new Room("Office", "desc", max, new string[] { "Second Floor" }));
rooms.Add(new Room("Secret Room", "desc", max, new string[] { "" }));
rooms.Add(new Room("Second Floor", "desc", max, new string[] { "Staircase to Second Floor", "Library", "Office", "Masters Bedroom", "Guest Bedroom" }));
rooms.Add(new Room("Staircase to Attic", "desc", max, new string[] { "Attic", "Library" }));
rooms.Add(new Room("Staircase to Second Floor", "desc", max, new string[] { "" }));
rooms.Add(new Room("Staircase to Basement", "desc", max, new string[] { "" }));
rooms.Add(new Room("room", "desc", max, new string[] { "" }));
rooms.Add(new Room("Storage Room", "desc", max, new string[] { "" }));
rooms.Add(new Room("room", "desc", max, new string[] { "" }));

//Skapa items

List<Item> items = new List<Item>();


//Skapa NPCs (att göra: sätta startrum på NPCs)
NPC Olivia = new NPC("Olivia", 26, "Female", "Chasier", "Murdered");
NPC Greg = new NPC("Greg", 28, "Male", "Carpenter", "Murdered");
NPC MsThompson = new NPC("Elizabeth Thompson", 48, "Female", "Unemployeed", "Murderer");
NPC MrThompson = new NPC("Gregoery Thomspon", 63, "Male", "Real estate manager", "Innocent");
NPC Jeeves = new NPC("Jeeves", 72, "Male", "The Butler", "Innocent");

//gissningsvariablen för att kunna avsluta eller fortsätta loopen ska flytta den sen.
string guess = Console.ReadLine();


//Välkomstmedelande + spelregler
Console.WriteLine("Welcome to Who killed Greg!");
Console.WriteLine();

//Skapa spelaren (player: string name, int age, string gender, string occupation, string status)

Console.WriteLine("Everyone went back to the house. The body of Greg is lying in the hallway.");
Console.WriteLine("Mr Thompson turned to you.");
Player player = new Player("MrSmith", 3, "Nonbinary", "Detective", "Innocent");
Console.WriteLine("What's your name?");
player.Name = Console.ReadLine();
Console.WriteLine($"Nice to meet you {player.Name}! And how old are you?");
player.Age = int.Parse(Console.ReadLine());



Console.WriteLine("Everyone went back to the house. The body of Greg is lying in the hallway.");
Console.WriteLine("Mr Thompson turned to you.");

//Spelloopen while loop 

while (player.isAlive == true || guess != "Ms Thompson" || guess != "Elizabetg" || guess != "")
{
    Console.WriteLine("What do you want to do?");
    string choice = Console.ReadLine();

    if (choice == "examine" || choice == "look" || choice == "clues")
    {
        Console.WriteLine();
    }

    if (choice == "go" || choice == "room" || choice == "change" || choice == "walk")
    {
        Console.WriteLine();
    }

    if (choice == "talk" || choice == "talk to")
    {
        Console.WriteLine();
    }

    if (choice == "guess" || choice == "killer" || choice == "murderer")
    {
        Console.WriteLine();
    }

    if (choice == "quit" || choice == "exit" || choice == "stop")
    {
        Console.WriteLine("Goodbye...");
        Environment.Exit(0);
    }

    Console.ReadLine();

}
