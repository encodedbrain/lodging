using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace lodging.Services;

public class ValidateCredentialsService
{
    public bool ValidatePassword(string password)
    {
        var regex = new Regex(
            "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"
        );

        if (string.IsNullOrEmpty(password) || !regex.IsMatch(password))
            return false;
        else
            return true;
    }

    public string EncryptingPassword(string password)
    {
        var hash = SHA1.Create();
        var encoding = new ASCIIEncoding();
        var arrayBytes = encoding.GetBytes(password);

        arrayBytes = hash.ComputeHash(arrayBytes);

        var strHex = new StringBuilder();

        foreach (var value in arrayBytes) strHex.Append(value.ToString("x2"));

        return strHex.ToString();
    }

    public bool ValidateCpf(string cpf)
    {
        var pattern = "^[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}";

        var rgx = new Regex(pattern);

        var cpfDigits = new List<int>();
        var nineDigitMultiplication = new List<int>();
        var tenDigitMultiplication = new List<int>();

        if (string.IsNullOrEmpty(cpf))
        {
            return false;
        }
        else
        {
            var checkingFormat = rgx.Match(cpf);

            if (checkingFormat.Success)
            {
                var cpfFormated = Regex.Replace(cpf, "[^0-9a-zA-Z]+", "");

                var arrayChars = cpfFormated.ToCharArray();

                for (var i = 0; i < 9; i++)
                {
                    var characters = (int)char.GetNumericValue(arrayChars[i]);
                    cpfDigits.Add(characters);
                }

                for (var i = 0; i < cpfDigits.Count; i++)
                {
                    var mult = cpfDigits[i] * (10 - i);

                    nineDigitMultiplication.Add(mult);
                }

                var calculateSumOfNine = nineDigitMultiplication.Aggregate(SumOfNineDigits);

                int SumOfNineDigits(int ac, int c)
                {
                    return ac + c;
                }

                var nineDigit = calculateSumOfNine * 10 % 11;

                if (nineDigit > 9)
                {
                    nineDigit = 0;
                    if (char.GetNumericValue(cpfFormated[9]) == nineDigit)
                        cpfDigits.Add(0);
                    else
                        return false;
                }
                else if (char.GetNumericValue(cpfFormated[9]) == nineDigit)
                {
                    cpfDigits.Add(nineDigit);
                }
                else
                {
                    return false;
                }

                for (var i = 0; i < cpfDigits.Count; i++) tenDigitMultiplication.Add(cpfDigits[i] * (11 - i));

                var calculateSumOfTen = tenDigitMultiplication.Aggregate(SumOfTenDigits);

                int SumOfTenDigits(int ac, int c)
                {
                    return ac + c;
                }

                var tenDigit = calculateSumOfTen * 10 % 11;

                if (tenDigit > 9)
                {
                    tenDigit = 0;
                    if (char.GetNumericValue(cpfFormated[10]) == tenDigit)
                        cpfDigits.Add(0);
                    else
                        return false;
                }
                else if (char.GetNumericValue(cpfFormated[10]) == tenDigit)
                {
                    cpfDigits.Add(tenDigit);
                }
                else
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool VaLidateEmail(string? email)
    {
        if (string.IsNullOrEmpty(email)) return false;

        var pattern = "^\\S+@\\S+\\.\\S+$";
        var rgx = new Regex(pattern);

        return rgx.IsMatch(email);
    }

    public bool ValidateName(string? name)
    {
        if (string.IsNullOrEmpty(name)) return false;

        if (name.Length > 30) return false;

        return true;
    }

    public string ReturnCpfFormated(string? cpf)
    {
        if (string.IsNullOrEmpty(cpf)) return "";

        if (!ValidateCpf(cpf)) return "";

        var cpfFormated = Regex.Replace(cpf, "[^0-9a-zA-Z]+", "");

        return cpfFormated;
    }

    public bool ValidatePhone(string? phone)
    {
        if (string.IsNullOrEmpty(phone))
            return false;

        var regex = new Regex("^\\+?[1-9][0-9]{7,14}$");

        if (regex.IsMatch(phone))
            return true;
        else
            return false;
    }

    public int GenerateIdentifier()
    {
        var random = new Random().Next();

        return random;
    }
}