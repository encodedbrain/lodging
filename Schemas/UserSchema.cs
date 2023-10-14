namespace lodging.Schemas;

public class UserSchema
{
    public UserSchema(string name, string email, string password, string cpf)
    {
        Name = name;
        Email = email;
        Password = password;
        Cpf = cpf;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Cpf { get; set; }
}