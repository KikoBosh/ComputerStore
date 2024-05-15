using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services.DTOs
{
    public class ImportDataDTO
    {
        public string Name { get; set; }
        public List<string> Categories { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
