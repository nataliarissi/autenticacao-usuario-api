namespace UserAuthenticationAPI.DbContextRepository.Models.Pagination
{
    public class PaginationRequestPerson<T>
    {
        public List<T> Items { get; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public PaginationRequestPerson(List<T> items, int currentPage, int totalPages)
        {
            Items = items;
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }
    }
}
