namespace lodging.Schemas;

public class ReserveSchema
{
    public ReserveSchema(string email, string password, string cpf, DateTime entryDate, DateTime departureDate, int rooms, string typeSuite)
    {
        Email = email;
        Password = password;
        Cpf = cpf;
        EntryDate = entryDate;
        DepartureDate = departureDate;
        Rooms = rooms;
        TypeSuite = typeSuite;
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string Cpf { get; set; }
    public DateTime EntryDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Rooms { get; set; }
    public string TypeSuite { get; set; }
    
    
}