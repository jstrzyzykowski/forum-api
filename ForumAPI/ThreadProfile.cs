using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumAPI.Entities;
using ForumAPI.Models;

namespace ForumAPI
{
    public class ThreadProfile : Profile
    {
        public ThreadProfile()
        {
            CreateMap<Thread, ThreadDetailsDto>();
        }
    }
}
