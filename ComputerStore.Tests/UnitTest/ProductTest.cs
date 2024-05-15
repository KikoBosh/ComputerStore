using AutoMapper;
using Moq;
using ComputerStore.Data.Entities;
using ComputerStore.Data.Interfaces;
using ComputerStore.Services.DTOs;
using ComputerStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;
using ComputerStore.WebApi.Services;

namespace ComputerStore.Tests.UnitTest
{
    public class ProductTest
    {
        IProductRepository productRepo;
        IMapper mapper;
        Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
        Product product;
        ProductDTO productDTO;
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        List<ProductDTO> productDTOList = new List<ProductDTO>();
        List<Product> products = new List<Product>();

        private Product GetProduct()
        {
            return new Product()
            {
                Id = 1,
                Name = "Laptop",
                Description = "A powerful laptop",
                Price = 999.99m,
                Categories = new List<Category> { new Category { Id = 1, Name = "Electronics" } }
            };
        }

        private ProductDTO GetProductDTO()
        {
            return new ProductDTO()
            {
                Id = 1,
                Name = "Laptop",
                Description = "A powerful laptop",
                Price = 999.99m,
                
            };
        }

        private List<Product> GetProducts()
        {
            return new List<Product> {
                new Product()
                {
                    Id = 1,
                    Name = "Laptop",
                    Description = "A powerful laptop",
                    Price = 999.99m,
                    Categories = new List<Category> { new Category { Id = 1, Name = "Electronics" } }
                },
                new Product
                {
                    Id = 2,
                    Name = "Keyboard",
                    Description = "Mechanical keyboard",
                    Price = 79.99m,
                    Categories = new List<Category> { new Category { Id = 2, Name = "Peripherals" } }
                }
            };
        }

        private void SetupMocks()
        {
            productRepo = productRepositoryMock.Object;
            mapper = mapperMock.Object;
        }

        private void SetupProductDTOListMock()
        {
            productDTO = GetProductDTO();
            var productDTO2 = GetProductDTO();
            productDTO2.Id = 2;
            productDTO2.Name = "Mouse";

            productDTOList.Add(productDTO);
            productDTOList.Add(productDTO2);

            products = GetProducts();

            mapperMock.Setup(o => o.Map<List<ProductDTO>>(products)).Returns(productDTOList);
        }

        private void SetupProductDTOMock()
        {
            product = GetProduct();
            mapperMock.Setup(o => o.Map<ProductDTO>(product)).Returns(GetProductDTO());
        }

        [Fact]
        public void GetProducts_ReturnsExpectedListOfProducts()
        {
            
            products = GetProducts();
            SetupMocks();
            SetupProductDTOListMock();

            productRepositoryMock.Setup(o => o.GetAll()).Returns(products);

            var productService = new ProductService(productRepo, mapper);

            
            var result = productService.GetAllProducts();

           
            Assert.True(result != null);
        }




    }
}
