namespace TestUp.Service.DTOs.Permission;

public class PermissionUpdateDto
{
    public long Id { get; set; }
    public bool Get { get; set; }
    public bool Create { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
}