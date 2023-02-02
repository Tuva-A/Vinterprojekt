using System;


public class Player : Person
{
    public int Time { get; set; }
    public bool isAlive = true;
    List<string> Inventory;

    public Player(string name, int age, string gender, string occupation, string status) : base(name, age, gender, occupation, status)
    {
        Inventory = new List<string>();
    }

    //man har 200 ticks i spelet att lista ut vem mördaren är
    //hämtade från tamagotchi
    public void Tick()
    {
        Time++;
        if (Time == 200)
        {
            isAlive = false;
            Console.WriteLine("You can hear footsteps behind you...");
            Console.WriteLine("You quickly turn around...");
            Console.WriteLine("BAAAM!");
            Console.WriteLine("You're to late...");
            Console.WriteLine("You got shot and did not find out whom the killers were!");
            Console.WriteLine("You loser.");
        }   
    }
}

