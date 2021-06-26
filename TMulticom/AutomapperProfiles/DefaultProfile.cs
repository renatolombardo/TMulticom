using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
            CreateMap<Amigo, AmigoRequest>().ReverseMap();
            CreateMap<Jogo, JogoRequest>().ReverseMap();
            CreateMap<Amigo, AmigoResponse>().ReverseMap();
            CreateMap<Jogo, JogoResponse>().ReverseMap();
        }
    }
}
