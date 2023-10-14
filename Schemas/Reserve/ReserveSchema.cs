namespace lodging.Schemas.Reserve;

public class ReserveSchema
{
    public ReserveSchema(string email, string password, string cpf, int rooms, string typeSuite, int days, int adults, int childrens)
    {
        Email = email;
        Password = password;
        Cpf = cpf;
        Rooms = rooms;
        TypeSuite = typeSuite;
        Days = days;
        Adults = adults;
        Childrens = childrens;
    }

    public ReserveSchema()
    {
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string Cpf { get; set; }
    public int Rooms { get; set; }
    public string TypeSuite { get; set; }
    public int Days { get; set; }
    public int Adults { get; set; }
    public int Childrens { get; set; }
}