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

        public Logic.Models.Product CreateProduct(Logic.Models.Product product)
        {
            Database.Models.Product productToCreate = new Database.Models.Product()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
            };
            _uow.ProductRepository.CreateProduct(productToCreate);
            _uow.Save();

            return new Logic.Models.Product()
            {
                Id = productToCreate.Id,
                ProductName = productToCreate.ProductName,
                ProductPrice = productToCreate.ProductPrice,
       
            };
        }

        public Logic.Models.Product UpdateProduct(Logic.Models.Product product)
        {
            Database.Models.Product productToUpdate = _uow.ProductRepository.GetById(product.Id);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductPrice = product.ProductPrice;

            _uow.ProductRepository.UpdateProduct(productToUpdate);
            _uow.Save();

            return new Logic.Models.Product()
            {
                Id = productToUpdate.Id,
                ProductName = productToUpdate.ProductName,
                ProductPrice = productToUpdate.ProductPrice

            };
        }

    }
}
