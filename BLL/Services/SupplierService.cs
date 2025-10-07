using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SupplierService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration( cfg =>
            {
                cfg.CreateMap<Supplier, SupplierDTO>().ReverseMap();

                cfg.CreateMap<Supplier, SupplierProductDTO>().ReverseMap();
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static bool Create(SupplierDTO s)
        {
            var data = GetMapper().Map<Supplier>(s);
            return DataAccessFactory.SupplierData().Create(data);
        }

        public static List<SupplierDTO> GetAll()
        {
            var data = DataAccessFactory.SupplierData().GetAll();
            return GetMapper().Map<List<SupplierDTO>>(data);
        }

        public static SupplierDTO GetById(int id)
        {
            var data = DataAccessFactory.SupplierData().Get(id);
            return GetMapper().Map<SupplierDTO>(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.SupplierData().Delete(id);
        }

        public static bool Update(SupplierDTO s)
        {
            var data = GetMapper().Map<Supplier>(s);
            return DataAccessFactory.SupplierData().Update(data);
        }

        public static SupplierProductDTO GetWithProducts(int id)
        {
            var data = DataAccessFactory.SupplierData().Get(id);
            return GetMapper().Map<SupplierProductDTO>(data);
        }

    }
}
