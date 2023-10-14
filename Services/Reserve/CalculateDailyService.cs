using lodging.Data;
using lodging.Schemas;
using lodging.Schemas.Reserve;

namespace lodging.Services;

public class CalculateDailyService
{
    public async Task<object> CalculateDaily(CalculateDailySchema prop)
    {
        var method = new ValidateCredentialsService();
        if (!ValidateCredentials(prop, method)) return false;

        using (var context = new LodgingDb())
        {
            var userExits = context.Persons.FirstOrDefault(person => person.Email == prop.Email
                                                                     && person.Password ==
                                                                     method.EncryptingPassword(prop.Password));

            if (userExits is null) return false;

            var reserve = context.Reserves.FirstOrDefault(reserve => reserve.Identifier == prop.Identifier
                                                                     && reserve.ReserveId == userExits.Id);

            if (reserve is null) return false;


            var daily = reserve.Daily;
            var days = reserve.Days;
            var total = DailyTotal(daily, days);


            return new
            {
                daily = total
            };
        }
    }

    private decimal DailyTotal(decimal daily, int days)
    {
        switch (days)
        {
            case >= 10 :
                return ((daily * days) * 10) / 100;
            case < 10:
                return daily * days;
        }
    }

    private bool ValidateCredentials(CalculateDailySchema prop, ValidateCredentialsService verifyCredentials)
    {
        if (!verifyCredentials.VaLidateEmail(prop.Email)) return false;
        if (!verifyCredentials.ValidatePassword(prop.Password)) return false;
        return true;
    }

}