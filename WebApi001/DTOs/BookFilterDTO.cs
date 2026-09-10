using WebApi001.Model;
namespace WebApi001.DTOs
{
    public class BookFilterDTO
    {
      public string? search {  get; set; } 

        // sorting
        public string? sortBy { get; set; }
        public string? sortOrder { get; set; } 
        //public int? AutherId { get; set; }
        //public int? CategoryId { get; set; }
        //public int? PublisherId { get; set; }
        //public int? PublicationYear { get; set; }

    }
}
