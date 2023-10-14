namespace lodging.Schemas.Reserve;

public class CalculateDailySchema
{
    public CalculateDailySchema(string email, string password, int identifier)
    {
        Email = email;
        Password = password;
        Identifier = identifier;
    }

    public CalculateDailySchema()
    {
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public int Identifier { get; set; }
}