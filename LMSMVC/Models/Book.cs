namespace LMSMVC.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? BookCode { get; set; }

        public string? Author { get; set; }
        public string? Title { get; set; }
        public DateTime? BookDate { get; set; }
        public decimal? Quantity { get; set; }
    }
}
