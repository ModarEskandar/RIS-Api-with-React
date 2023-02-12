namespace Data.Entities;

public class BaseEntity
{
    public int Id { get; set; }

}
public class Person : BaseEntity
{
    public string FirstName { get; set; }
    public string middleName { get; set; }
    public string LastName { get; set; }
}