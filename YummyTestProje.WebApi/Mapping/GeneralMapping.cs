using AutoMapper;
using AutoMapper.Features;
using YummyTestProje.WebApi.DTO.CategoryDTO;
using YummyTestProje.WebApi.DTO.FeatureDTO;
using YummyTestProje.WebApi.DTO.MessageDTO;
using YummyTestProje.WebApi.DTO.ProductDTO;
using YummyTestProje.WebApi.Entities;

namespace YummyTestProje.WebApi.Mapping
{
    public class GeneralMapping:Profile
    {

        public GeneralMapping()
        {
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();

            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, ResultMessageDTO>().ReverseMap();
            CreateMap<Message, GetByIdMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();

            CreateMap<Product,CreateProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDTO>().ForMember(x=>x.CategoryName,y=>y.MapFrom(z => z.Category.CategoryName)).ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();


            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            




        }
    }
}
