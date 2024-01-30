namespace UserAuthenticationAPI.DbContextRepository
{
    public class Pagination<T>
    {
        public List<T> Items { get; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public Pagination(List<T> items, int currentPage, int totalPages)
        {
            Items = items;
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }
    }
}
