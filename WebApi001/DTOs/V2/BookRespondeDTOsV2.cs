namespace WebApi001.DTOs.V2
{
    public class BookRespondeDTOsV2
    {
        public int BookId { get; set; }
        public string Isbn { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int? PublicationYear { get; set; }
    }
}
