using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceBssl.Data
{
    public class Address
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string State { get; set; }
        public string ActualAddress { get; set; }

        public string CustomerId { get; set; }
    }

}
