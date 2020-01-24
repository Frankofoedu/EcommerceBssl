using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceBssl.Data
{
    public class ProductColour
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColourId { get; set; }

        public Product Product { get; set; }
        public Colour Colour { get; set; }
    }
}
