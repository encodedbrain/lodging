namespace lodging.Schemas.Person;

public class UpdatePersonSchema
{
    public UpdatePersonSchema(string email, string password, string field, string update)
    {
        Email = email;
        Password = password;
        Field = field;
        Update = update;
    }

    public UpdatePersonSchema()
    {
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string Field { get; set; }
    public string Update { get; set; }
}