namespace gamecenter.Shared.DTOs
{
    public class PageResponse<T>
    {
       public T Response { get; set; }
       public int AmountOfPages { get; set; } 
    }
}