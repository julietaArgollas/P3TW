using System;
using System.Collections.Generic;
using System.Text;
using Database;

namespace Logic.Managers
{
    public class ProductManager
    {
        public UnitOfWork _uow;
        public ProductManager(UnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Logic.Models.Product> GetProduct()
        {
            List<Database.Models.Product> productFromBD = _uow.ProductRepository.GetAll().Result;
            List<Logic.Models.Product> mappedProduct = new List<Models.Product>();
            foreach(Database.Models.Product product in productFromBD)
            {
                mappedProduct.Add(new Logic.Models.Product()
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductPrice=product.ProductPrice

                });
            }
            return mappedProduct;
        }
    }
}
