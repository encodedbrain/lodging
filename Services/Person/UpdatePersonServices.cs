using lodging.Data;
using lodging.Schemas.Person;

namespace lodging.Services.Person;

public class UpdatePersonServices
{
    public async Task<bool> UpdatePerson(UpdatePersonSchema prop)
    {
        var method = new ValidateCredentialsService();

        if (!VerifyCredentials(prop, method)) return false;

        using (var context = new LodgingDb())
        {
            var userExists = context.Persons.FirstOrDefault(person =>
                person.Email == prop.Email && person.Password == method.EncryptingPassword(prop.Password));


            if (userExists is null) return false;
            
            switch (prop.Field)
            {
                case "password":
                    userExists.Password = method.EncryptingPassword(prop.Update);
                    break;
                case "email":
                    userExists.Email = prop.Update;
                    break;
            }


            context.Persons.Update(userExists);
            await context.SaveChangesAsync();
        }


        return true;
    }

    private bool VerifyCredentials(UpdatePersonSchema prop, ValidateCredentialsService verifyCredentials)
    {
        if (!verifyCredentials.ValidatePassword(prop.Password)) return false;
        if (!verifyCredentials.VaLidateEmail(prop.Email)) return false;
        return true;
    }
}