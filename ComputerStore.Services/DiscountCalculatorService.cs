using System.Collections.Generic;
using System.Linq;
using ComputerStore.Data.Entities;
using ComputerStore.Services.DTOs;

namespace ComputerStore.Services
{
    public class DiscountCalculatorService
    {
        public decimal CalculateDiscount(IEnumerable<ProductDTO> basket)
        {
            decimal totalDiscount = 0;

            
            var groupedProducts = basket.GroupBy(p => p.Categories.FirstOrDefault()?.Id);

            foreach (var group in groupedProducts)
            {
                
                if (group.Count() > 1)
                {
                    
                    totalDiscount += group.Skip(1).Sum(p => p.Price) * 0.05m;
                }
            }

            return totalDiscount;
        }
    }
}
