using ComputerStore.Data.Entities;
using ComputerStore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerStore.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ComputerStoreContext _context;

        public ProductRepository(ComputerStoreContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product AddProduct(Product productEntity)
        {
            _context.Products.Add(productEntity);
            _context.SaveChanges();
            return productEntity; 
        }

        public bool Delete(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Categories = product.Categories;
                _context.SaveChanges();
            }
        }
    }
}
