using AutoMapper;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.AboutDtos;
using SignalRApi.Dtos.BasketDtos;
using SignalRApi.Dtos.BookingDtos;
using SignalRApi.Dtos.CategoryDtos;
using SignalRApi.Dtos.ContactDtos;
using SignalRApi.Dtos.FeatureDtos;
using SignalRApi.Dtos.ProductDtos;
using SignalRApi.Dtos.SliderDtos;
using SignalRApi.Dtos.SocialMediaDtos;
using SignalRApi.Dtos.TestimonialDtos;

namespace SignalRApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<About, AboutDto>().ReverseMap(); 
            CreateMap<Booking,BookingDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Slider, SliderDto>().ReverseMap();


            //// Booking, Category, Contact, Discount, Feature, Product, SocialMedia, Testimonial, Title
            //var classes = new List<Type> { typeof(Booking), typeof(Category), typeof(Contact), typeof(Discount), typeof(Feature), typeof(Product), typeof(SocialMedia), typeof(Testimonial), typeof(Title) };

            //foreach (var classType in classes)
            //{
            //    CreateMap(classType, typeof(ResultDto<>).MakeGenericType(classType))
            //        .ForMember("Data", opt => opt.MapFrom(src => src));

            //    CreateMap(classType, typeof(GetDto<>).MakeGenericType(classType))
            //        .ForMember("Data", opt => opt.MapFrom(src => src));

            //    CreateMap(classType, typeof(CreateDto<>).MakeGenericType(classType))
            //        .ForMember("Data", opt => opt.MapFrom(src => src));

            //    CreateMap(classType, typeof(UpdateDto<>).MakeGenericType(classType))
            //        .ForMember("Data", opt => opt.MapFrom(src => src));
            //}
        }
    }


}
