namespace DataBaseAccessLayer.Enitites;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public DateTime CreatedDate { get; set; }
}

