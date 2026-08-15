namespace WebApi001.DTOs
{
    public class UpdateBookDTOs
    {
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public int? PublicationYear { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
    }
}
