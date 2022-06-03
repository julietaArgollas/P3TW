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

        public Logic.Models.ListProduct CreateListProduct(Logic.Models.ListProduct listproduct)
        {
            Database.Models.ListProduct listProductToCreate = new Database.Models.ListProduct()
            {
                Id = listproduct.Id,
                ListName = listproduct.ListName,
                Description = listproduct.Description,
                //Products = product.Products,
                Type = listproduct.Type
            };
            _uow.ListProductRepository.CreateListProduct(listProductToCreate);
            _uow.Save();

            return new Logic.Models.ListProduct()
            {
                Id = listProductToCreate.Id,
                ListName = listProductToCreate.ListName,
                Description = listProductToCreate.Description,
                //Products = product.Products,
                Type = listProductToCreate.Type
            };
        }

        public Logic.Models.ListProduct UpdateListProduct(Logic.Models.ListProduct listProduct)
        {
            Database.Models.ListProduct listProductToUpdate = _uow.ListProductRepository.GetById(listProduct.Id);

            listProductToUpdate.ListName = listProduct.ListName;
            listProductToUpdate.Description = listProduct.Description;

            _uow.ListProductRepository.UpdateListProduct(listProductToUpdate);
            _uow.Save();

            return new Logic.Models.ListProduct()
            {
                Id = listProductToUpdate.Id,
                ListName = listProductToUpdate.ListName,
                Description = listProductToUpdate.Description

            };
        }

    }
}
