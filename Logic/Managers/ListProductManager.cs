using System;
using System.Collections.Generic;
using System.Text;
using Database;

namespace Logic.Managers
{
    public class ListProductManager
    {
        private UnitOfWork _uow;
       
        public ListProductManager(UnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Logic.Models.ListProduct> GetListProduct()
        {
            List<Database.Models.ListProduct> productFromDB = _uow.ListProductRepository.GetAll().Result;
            List<Logic.Models.ListProduct> mappedListProduct = new List<Logic.Models.ListProduct>();

            foreach (Database.Models.ListProduct product in productFromDB)
            {
                mappedListProduct.Add(new Logic.Models.ListProduct()
                {
                    ListName = product.ListName,
                    Description = product.Description,
                    //Products = product.Products,
                    Type = product.Type
                }); 
            }

            return mappedListProduct;
        }

        public Logic.Models.ListProduct CreateListProduct(Logic.Models.ListProduct listproduct)
        {
            Database.Models.ListProduct listProductToCreate = new Database.Models.ListProduct()
            {
                Id= listproduct.Id,
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
