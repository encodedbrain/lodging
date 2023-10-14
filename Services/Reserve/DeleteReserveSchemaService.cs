using lodging.Data;
using lodging.Schemas;
using lodging.Schemas.Reserve;

namespace lodging.Services;

public class DeleteReserveSchemaService
{
    public async Task<bool> DeleteReserve(DeleteReserveSchema prop)
    {
        var method = new ValidateCredentialsService();

        if (!ValidateCredentials(prop, method)) return false;

        using (var context = new LodgingDb())
        {
            var userExists = context.Persons.FirstOrDefault(person =>
                person.Password == method.EncryptingPassword(prop.Password)
                && person.Cpf == prop.Cpf && person.Email == prop.Email
            );
            if (userExists is null) return false;

            var reserve = context.Reserves.FirstOrDefault(reserve => reserve.Identifier == prop.IdentifierReserve && reserve.ReserveId == userExists.Id);

            var suite = context.Suites.FirstOrDefault(suite =>
                suite.TypeSuite == prop.SuiteType
                && suite.Identifier == prop.IdentifierSuite && suite.SuiteId == userExists.Id);

            if (reserve is null || suite is null) return false;

            context.Reserves.Remove(reserve);
            context.Suites.Remove(suite);
            await context.SaveChangesAsync();
        }

        return true;
    }

    private bool ValidateCredentials(DeleteReserveSchema prop, ValidateCredentialsService verifyCredentials)
    {

        if (!verifyCredentials.ValidateCpf(prop.Cpf)) return false;
        if (!verifyCredentials.VaLidateEmail(prop.Email)) return false;
        if (!verifyCredentials.ValidatePassword(prop.Password)) return false;
        
        return true;
    }
}