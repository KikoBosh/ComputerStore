using System.Collections.Generic;
using ComputerStore.Services.DTOs;

namespace ComputerStore.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        ProductDTO AddProduct(ProductDTO product);
        ProductDTO UpdateProduct(ProductDTO product);
        bool DeleteProduct(int id);
    }
}