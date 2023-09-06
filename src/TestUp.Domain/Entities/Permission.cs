using TestUp.Domain.Commons;

public class Permission : Auditable
{
    public bool Get { get; set; }
    public bool Create { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
}