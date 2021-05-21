namespace gamecenter.Shared.DTOs
{
    public class GameFilterDTO
    {
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
        public PageDTO Pagination 
        {
            get { return new PageDTO() { Page = Page, ItemsPerPage = ItemsPerPage}; }
        }
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}