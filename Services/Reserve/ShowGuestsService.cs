using lodging.Data;
using lodging.Schemas;

namespace lodging.Services;

public class ShowGuestsService
{
    public async Task<object> ShowGuests(ShowGuestsSchema prop)
    {
        using (var context = new LodgingDb())
        {
            var method = new ValidateCredentialsService();
            if (!ValidateCredentials(prop, method)) return false;

            var userExists = context.Persons.FirstOrDefault(person => person.Password == method.EncryptingPassword(prop.Password)
            && person.Email == prop.Email);

            if (userExists is null) return false;

            var guests = context.Reserves.FirstOrDefault(reserve => reserve.ReserveId == userExists.Id);

            if (guests is null) return false;

            return new
            {
                adults = guests.Adults,
                childrens = guests.Childrens
            };
        }
    }
    private bool ValidateCredentials(ShowGuestsSchema prop, ValidateCredentialsService verifyCredentials)
    {
        if (!verifyCredentials.VaLidateEmail(prop.Email)) return false;
        if (!verifyCredentials.ValidatePassword(prop.Password)) return false;
        return true;
    }
}