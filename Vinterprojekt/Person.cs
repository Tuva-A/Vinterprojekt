using System;



public class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Occupation { get; set; }
    public string Status { get; set; }

    public Person(string name, int age, string gender, string occupation, string status)
    {
        Name = name;
        Age = age;
        Gender = gender;
        Occupation = occupation;
        Status = status;
    }
}
