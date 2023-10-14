using lodging.Data;
using lodging.Models;
using lodging.Schemas;

namespace lodging.Services;

public class NewReserveService
{
    public async Task<bool> NewRerseve(ReserveSchema prop)
    {
        var method = new ValidateCredentialsService();

        if (!VerifyCredentials(prop, method)) return false;

        using (var context = new LodgingDb())
        {
            var userExists = context.Persons.FirstOrDefault(
                person => person.Password == method.EncryptingPassword(prop.Password)
                          && person.Email == prop.Email
                          && person.Cpf == prop.Cpf
            );

            if (userExists is null) return false;

            var newReserve = new Reserve()
            {
                DepartureDate = DateTime.Now,
                EntryDate = DateTime.Now, Person = userExists,
                Identifier = method.GenerateIdentifier()
                
            };
            var newSuite = new Suite()
            {
                Rooms = prop.Rooms,
                TypeSuite = prop.TypeSuite,
                Identifier = method.GenerateIdentifier(),
                Person = userExists
            };

            await context.Reserves.AddAsync(newReserve);
            await context.Suites.AddAsync(newSuite);
            await context.SaveChangesAsync();
        }

        return true;
    }

    public bool VerifyCredentials(ReserveSchema prop, ValidateCredentialsService verifyCredentials)
    {
        if (!verifyCredentials.ValidatePassword(prop.Password)) return false;
        if (!verifyCredentials.VaLidateEmail(prop.Email)) return false;
        if (!verifyCredentials.ValidateCpf(prop.Cpf)) return false;

        return true;
    }
}