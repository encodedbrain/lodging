namespace lodging.Models;

public class Reserve
{
    public Reserve(DateTime entryDate, DateTime departureDate, int childrens, int adults, decimal daily, int days, int identifier)
    {
        EntryDate = entryDate;
        DepartureDate = departureDate;
        Childrens = childrens;
        Adults = adults;
        Daily = daily;
        Days = days;
        Identifier = identifier;
    }


    public Reserve(){}


    public int Id { get; set; }
    public DateTime EntryDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Childrens { get; set; }
    public int  Adults { get; set; }
    public decimal Daily { get; set; }
    public int Days { get; set; }
    public int Identifier { get; set; }
    public Person Person { get; set; }
    public int  ReserveId { get; set; }
}