using lodging.Data;
using lodging.Models;
using lodging.Schemas;

namespace lodging.Services;

public class ReservationService
{
    public async Task<object> Reservation(reservationSchema prop)
    {
        var method = new ValidateCredentialsService();

        if (!ValidateCredentials(prop, method)) return null!;


        using (var context = new LodgingDb())
        {
            var generateToken = new TokenServices();
            var newReserve = new Person()
            {
                Name = prop.Name,
                Cpf = prop.Cpf,
                Email = prop.Email,
                Password = method.EncryptingPassword(prop.Password),
                Reserve = new List<Reserve>()
                {
                    new()
                    {
                        DepartureDate = DateTime.Now,
                        EntryDate = DateTime.Now,
                        Identifier = method.GenerateIdentifier() 
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

    public bool ValidateCredentials(reservationSchema prop, ValidateCredentialsService verifyCredentials)
    {
        if (!verifyCredentials.ValidateCpf(prop.Cpf)) return false;
        if (!verifyCredentials.ValidatePhone(prop.Phone)) return false;
        if (!verifyCredentials.VaLidateEmail(prop.Email)) return false;
        if (!verifyCredentials.ValidateName(prop.Name)) return false;
        if (!verifyCredentials.ValidatePassword(prop.Password)) return false;

        return true;
    }
}