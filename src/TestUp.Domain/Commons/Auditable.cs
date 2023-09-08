using TestUp.Domain.Constans;

namespace TestUp.Domain.Commons;

public class Auditable
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; } = Time.GetCurrentTime();
}