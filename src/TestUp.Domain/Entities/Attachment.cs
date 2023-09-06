using TestUp.Domain.Commons;

public class Attachment : Auditable
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
}