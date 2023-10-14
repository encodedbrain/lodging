namespace lodging.Models;

public class Person
{
    public Person(int id, string name, string email, string password, string cpf)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Cpf = cpf;
    }


    public Person()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Cpf { get; set; }
    public IEnumerable<Reserve> Reserve { get; set; }
    public IEnumerable<Suite> Suites { get; set; }
}