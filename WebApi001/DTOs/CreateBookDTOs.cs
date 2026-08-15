namespace WebApi001.DTOs
{
    public class CreateBookDTOs
    {
     
        public string Isbn { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public int? PublicationYear { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

    }
}
