using lodging.Data;
using lodging.Schemas;

namespace lodging.Services;

public class LoginServices
{
    public object GetToken(LoginSchema prop)
    {
        var generateToken = new TokenServices();
        var method = new ValidateCredentialsService();

        if (!VerifyCredentials(prop, method)) return null!;

        using (var context = new LodgingDb())
        {
            var userExists = context.Persons.FirstOrDefault(person =>
                person.Password == method.EncryptingPassword(prop.Password)
                && person.Cpf == prop.Cpf);

            if (userExists is null) return false;

            var queryPerson = context.Persons.Find(userExists.Id);

            if (queryPerson is null) return null!;

            var token = generateToken.GenerateToken(queryPerson);
            return token;
        }
    }

    public bool VerifyCredentials(LoginSchema prop, ValidateCredentialsService verifyCredentials)
    {
        if (!verifyCredentials.ValidatePassword(prop.Password)) return false;
        if (!verifyCredentials.VaLidateEmail(prop.Email)) return false;
        if (!verifyCredentials.ValidateCpf(prop.Cpf)) return false;
        return true;
    }
}