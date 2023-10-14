namespace lodging.Models;

public class Suite
{
    public Suite(int rooms, string typeSuite, int identifier)
    {
        Rooms = rooms;
        TypeSuite = typeSuite;
        Identifier = identifier;
    }

    public Suite()
    {
    }


    public int Id { get; set; }
    public int Rooms { get; set; }
    public string TypeSuite { get; set; }

    public int Identifier { get; set; }

    public Person Person { get; set; }
    public int SuiteId { get; set; }
}