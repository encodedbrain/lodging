namespace lodging.Schemas;

public class ReservationSchema
{
    protected ReservationSchema(string name, string email, string password, string cpf, string phone, int room, string suite, int days, int childrens, int adults)
    {
        Name = name;
        Email = email;
        Password = password;
        Cpf = cpf;
        Phone = phone;
        Room = room;
        Suite = suite;
        Days = days;
        Childrens = childrens;
        Adults = adults;
    }

    public ReservationSchema()
    {
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Cpf { get; set; }
    public string Phone { get; set; }
    public int Room { get; set; }
    public string Suite { get; set; } 
    public int Days { get; set; }
    public int Childrens { get; set; }
    public int Adults { get; set; }
}