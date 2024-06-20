using AutoMapper;
using Bl.BlModels;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bl.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            {
                CreateMap<FullDietitian, Dal.Models.Dietitian>().
                    ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id)).
                     ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email)).
                      ForMember(dest => dest.FirstName, source => source.MapFrom(src => src.FirstName)).
                       ForMember(dest => dest.LastName, source => source.MapFrom(src => src.LastName)).
                        ForMember(dest => dest.Kind, source => source.MapFrom(src => src.Kind)).
                         ForMember(dest => dest.Phone, source => source.MapFrom(src => src.Phone));
                CreateMap<Dal.Models.Dietitian, Bl.BlModels.BlDietitian>();
                CreateMap<Dal.Models.Dietitian, Bl.BlModels.Dietitian>();
                CreateMap<Dal.Models.Meeting, Bl.BlModels.AllTheDetailsOfMeeting>();
                CreateMap<Dal.Models.Client, Bl.BlModels.Client>();
                CreateMap<Bl.BlModels.Client, Dal.Models.Client>();
                CreateMap<Dal.Models.Client, Bl.BlModels.ClientForGet>();
                CreateMap<Bl.BlModels.Meeting, Dal.Models.Meeting>();
                CreateMap<QueuesForDietitian, BlQueuesForDietitian>();
            }
        }
    }
}
