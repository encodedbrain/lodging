namespace lodging.Schemas;

public class DeleteReserveSchema
{
    public DeleteReserveSchema(string email, string password, string cpf, string suiteType, int identifierReserve, int identifierSuite)
    {
        Email = email;
        Password = password;
        Cpf = cpf;
        SuiteType = suiteType;
        IdentifierReserve = identifierReserve;
        IdentifierSuite = identifierSuite;
    }


    public string Email { get; set; }
    public string Password { get; set; }
    public string Cpf { get; set; }
    public string SuiteType { get; set; }
    public int IdentifierReserve { get; set; }
    public int IdentifierSuite { get; set; }
}