using System;
//namespace Vinterprojekt;


public class Room
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxOccupants { get; set; }
    public string[] Exits { get; set; }

    public Room(string name,string description,int maxOccupants,string[] exits){
        Name=name;
        Description=description;
        MaxOccupants=maxOccupants;
        Exits=exits;
    }
}
