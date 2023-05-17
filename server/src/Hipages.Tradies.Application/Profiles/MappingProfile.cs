namespace Hipages.Tradies.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Job, GetJobListViewModel>()
            .ConstructUsing(src => new GetJobListViewModel
            {
                Id = src.Id,
                Status = src.Status,
                CategoryName = src.Category.Name,
                ContactEmail = src.Contact.Email,
                ContactName = src.Contact.Name,
                ContactPhone = src.Contact.Phone,
                SuburbName = src.Suburb.Name,
                Postcode = src.Suburb.Postcode,
                Price = src.Price,
                Description = src.Description,
                CreatedAt = src.CreatedAt,
                UpdatedAt = src.UpdatedAt,
            });

        CreateMap<UpdateJobCommand, Job>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Contact,
                opt => opt.MapFrom(src => new Contact(src.ContactName, src.ContactPhone, src.ContactEmail)))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

    }
}