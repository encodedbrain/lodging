namespace lodging.Schemas.Person;

public class LoginSchema
{
    public LoginSchema(string password, string email, string cpf)
    {
        Password = password;
        Email = email;
        Cpf = cpf;
    }

    public LoginSchema()
    {
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string Cpf { get; set; } 
}