using lodging.Data;
using lodging.Models;
using lodging.Schemas;

namespace lodging.Services.Reserve;

public class ReservationService
{
    public async Task<object> Reservation(ReservationSchema prop)
    {
        var method = new ValidateCredentialsService();

        if (!ValidateCredentials(prop, method)) return null!;


        using (var context = new LodgingDb())
        {
            var generateToken = new TokenServices();
            var newReserve = new Models.Person()
            {
                Name = prop.Name,
                Cpf = method.ReturnCpfFormated(prop.Cpf),
                Email = prop.Email,
                Password = method.EncryptingPassword(prop.Password),
                Reserve = new List<Models.Reserve>()
                {
                    new()
                    {
                        DepartureDate = DateTime.Now.AddDays(prop.Days),
                        EntryDate = DateTime.Now,
                        Identifier = method.GenerateIdentifier(),
                        Daily = method.VerifyTypeSuite(prop.Suite),
                        Days =  prop.Days,
                        Adults = prop.Adults,
                        Childrens = prop.Childrens
                    }
                },
                Suites = new List<Suite>()
                {
                    new()
                    {
                        Rooms = prop.Room,
                        TypeSuite = prop.Suite,
                        Identifier = method.GenerateIdentifier() 
                    }
                }
            };
            await context.Persons.AddAsync(newReserve);
            await context.SaveChangesAsync();

            var token = generateToken.GenerateToken(newReserve);

            foreach (var value in newReserve.Reserve)
            {
                value.Person.Password = string.Empty;
                value.Person.Cpf = string.Empty;
            }

            return new
            {
                newReserve, token
            };
        }
    }

    private bool ValidateCredentials(ReservationSchema prop, ValidateCredentialsService verifyCredentials)
    {
        if (!verifyCredentials.ValidateCpf(prop.Cpf)) return false;
        if (!verifyCredentials.ValidatePhone(prop.Phone)) return false;
        if (!verifyCredentials.VaLidateEmail(prop.Email)) return false;
        if (!verifyCredentials.ValidateName(prop.Name)) return false;
        if (!verifyCredentials.ValidatePassword(prop.Password)) return false;

        return true;
    }
}