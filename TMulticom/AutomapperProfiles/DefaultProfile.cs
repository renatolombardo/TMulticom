using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TMulticom.Domain.Models;
using TMulticom.Web.Model.Requests;
using TMulticom.Web.Model.Responses;

namespace TMulticom.Web.Profiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<Amigo, AmigoRequest>()
                .ForSourceMember(x => x.UserId, opt => opt.DoNotValidate())
                .ReverseMap();
            CreateMap<Jogo, JogoRequest>()
                .ForSourceMember(x => x.UserId, opt => opt.DoNotValidate())
                .ReverseMap();
            CreateMap<Amigo, AmigoResponse>()
                .ForSourceMember(x => x.UserId, opt => opt.DoNotValidate())
                .ReverseMap();
            CreateMap<Jogo, JogoResponse>()
                .ForSourceMember(x => x.UserId, opt => opt.DoNotValidate())
                .ReverseMap();
        }
    }
}
