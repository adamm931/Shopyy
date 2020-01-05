using AutoMapper;
using System;

namespace Shopyy.Application.Mapping
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            // Enum to string mapping
            CreateMap<Enum, string>()
                .ConvertUsing(src => src.ToString());
        }
    }
}
