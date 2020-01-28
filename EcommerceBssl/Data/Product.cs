using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceBssl.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }
        public IList<ProductColour> ProductColours { get; set; }
        public IList<Image> Images { get; set; }
    }
}
