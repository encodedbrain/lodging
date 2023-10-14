namespace lodging.Schemas;

public class CalculateDaily
{
    public CalculateDaily(string email, string password, int identifier)
    {
        Email = email;
        Password = password;
        Identifier = identifier;
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public int Identifier { get; set; }
}