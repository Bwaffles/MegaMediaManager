using AutoMapper;
using MegaMediaManager.Model;
using MegaMediaManager.Mvc.Models;

namespace MegaMediaManager.Mvc.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Start()
        {
            Mapper.CreateMap<User, DisplayUser>();
            Mapper.CreateMap<User, RegisterViewModel>().ForMember(x => x.ConfirmPassword, y => y.Ignore());

            Mapper.AssertConfigurationIsValid();
        }
    }
}