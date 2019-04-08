using AutoMapper;
using EmailQueueApp.Data.Entity;
using EmailQueueApp.ViewModel;
using EmailQueueApp.ViewModel.Enums;

namespace EmailQueueApp.Infrastructure.Util
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MailingAddressEM, MailingAddressVM>().ReverseMap();
            CreateMap<MailingEM, MailingVM>().ReverseMap();
            CreateMap<AddressPM, MailingAddressEM>().ReverseMap();
            CreateMap<CreateMailingPM, MailingEM>().ReverseMap();

            CreateMap<MailingReportAddressEM, MailingReportAddressVM>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (MailStatus)src.StatusId));
        }
    }
}
