using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel;
using AutoMapper;

namespace BusinessServices
{
    public class ProductServices : IProductServices
    {
        WebApiDbEntities db = new WebApiDbEntities();
        public int CreateProduct(ProductEntity productEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {

            
            var productEntity = new ProductEntity();
            var product = db.Products;
            Mapper
            Mapper.CreateMap<Product, ProductEntity>();
            //var products = _unitOfWork.ProductRepository.GetAll().ToList();
            //if (products.Any())
            //{
            //    Mapper.CreateMap<Product, ProductEntity>();
            //    var productsModel = Mapper.Map<List<Product>, List<ProductEntity>>(products);
            //    return productsModel;
            //}
            return null;
           // return db.Products.ToList();
            
            
        }

        public ProductEntity GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(int productId, ProductEntity productEntity)
        {
            throw new NotImplementedException();
        }

        
    }
}
