using lodging.Models;

namespace lodging.Schemas;

public class reservationSchema
{
    public reservationSchema(string name, string email, string password, string cpf, string phone, DateTime departureDate, DateTime entryDate, int room, string suite)
    {
        Name = name;
        Email = email;
        Password = password;
        Cpf = cpf;
        Phone = phone;
        DepartureDate = departureDate;
        EntryDate = entryDate;
        Room = room;
        Suite = suite;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public string Cpf { get; set; }
    public string Phone { get; set; }

    public DateTime DepartureDate { get; set; }
    public DateTime EntryDate { get; set; }
    public int Room { get; set; }
    public string Suite { get; set; }
}