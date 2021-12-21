using AuthManager.Utilities.JWT;
using Autofac;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Concrete.EntityFramework.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IoC
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<CategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();
            builder.RegisterType<RoleDal>().As<IRoleDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CountyDal>().As<ICountyDal>().SingleInstance();
            builder.RegisterType<CityDal>().As<ICityDal>().SingleInstance();
            builder.RegisterType<AddressDal>().As<IAddressDal>().SingleInstance();
            builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();

            builder.RegisterType<OrderDal>().As<IOrderDal>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();

            builder.RegisterType<JWTToken>().As<IJWTToken>().SingleInstance();

        }
    }
}
