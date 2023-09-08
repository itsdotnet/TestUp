namespace TestUp.Domain.Configurations;

public class PaginationParams
{
    private int pageSize;
    private const int maxSize = 20;

    public int PageSize
    {
        get => pageSize == 0 ? maxSize : pageSize;
        set { pageSize = value > maxSize ? maxSize : value; }
    }

    public int PageIndex { get; set; } = 1;
}