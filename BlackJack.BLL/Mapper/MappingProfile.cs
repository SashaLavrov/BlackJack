using AutoMapper;
using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CurrentCardPlayerStateViewItem>();
            CreateMap<CurrentCardPlayerStateViewItem, Card>();
        }
    }
}
