using Mapster;
using WebApi001.Model;
using WebApi001.DTOs;
namespace WebApi001.Mappings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Book, BookRespondeDTOs>.NewConfig()
                .Map(dest => dest.Author, src => src.Author.Name)
                .Map(dest => dest.Category, src => src.Category.Name)
                .Map(dest => dest.Publisher, src => src.Publisher != null ? src.Publisher.Name : null);
        }
    }
}
