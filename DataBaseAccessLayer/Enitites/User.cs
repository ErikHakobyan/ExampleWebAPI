namespace DataBaseAccessLayer.Enitites;

public class User : BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public UserType UserType { get; set; }
}

