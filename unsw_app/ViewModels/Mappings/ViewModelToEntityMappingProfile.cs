using AutoMapper;
using unsw_app.Models.Entities;

namespace unsw_app.ViewModels.Mappings 
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
              CreateMap<RegistrationViewModel,AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}