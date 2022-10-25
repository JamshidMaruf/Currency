namespace Currency.Web.Configurations;

public class PaginationMetaData<T> : List<T>
{
    public PaginationMetaData(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        this.AddRange(items);
    }

    public int PageIndex { get; set; }
    public int TotalPages { get; set; }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
}

