namespace WebApi001.DTOs
{
    public class BookRespondeDTOs
    {

        
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? Publisher { get; set; } = string.Empty;
        public int? PublicationYear { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
    }
}
