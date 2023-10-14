namespace lodging.Schemas;

public class ShowGuestsSchema
{
    public ShowGuestsSchema(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public ShowGuestsSchema()
    {
    }

    public string Email { get; set; }
    public string Password { get; set; }
}