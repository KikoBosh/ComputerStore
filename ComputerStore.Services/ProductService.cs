using System;
using System.Collections.Generic;
using AutoMapper;
using ComputerStore.Services.DTOs;
using ComputerStore.Services.Interfaces;
using ComputerStore.Data.Entities;
using ComputerStore.Data.Interfaces;

namespace ComputerStore.WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is not initialized.");
        }



        public ProductDTO AddProduct(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            var addedProduct = _productRepository.AddProduct(productEntity);
            return _mapper.Map<ProductDTO>(addedProduct);
        }

        public bool DeleteProduct(int id)
        {   
            var product = _productRepository.GetById(id);
            return _productRepository.Delete(product);
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public ProductDTO UpdateProduct(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            _productRepository.Update(productEntity);
            return product;
        }
    }
}
