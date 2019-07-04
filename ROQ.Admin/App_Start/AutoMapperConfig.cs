using AutoMapper;
using ROQ.Data.Entities;
using ROQ.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROQ.Admin.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Users, UsersVM>();
            });
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Users, UsersViewModel>();
            //});
        }
    }
}