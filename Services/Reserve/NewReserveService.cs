using lodging.Data;
using lodging.Models;
using lodging.Schemas.Reserve;

namespace lodging.Services.Reserve;

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

            var newReserve = new Models.Reserve()
            {
                DepartureDate = DateTime.Now.AddDays(prop.Days),
                EntryDate = DateTime.Now, Person = userExists,
                Identifier = method.GenerateIdentifier(),
                Daily = method.VerifyTypeSuite(prop.TypeSuite),
                Days =  prop.Days,
                Adults = prop.Adults,
                Childrens = prop.Childrens
                
                
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

    private bool VerifyCredentials(ReserveSchema prop, ValidateCredentialsService verifyCredentials)
    {
        if (!verifyCredentials.ValidatePassword(prop.Password)) return false;
        if (!verifyCredentials.VaLidateEmail(prop.Email)) return false;
        if (!verifyCredentials.ValidateCpf(prop.Cpf)) return false;

        return true;
    }
}