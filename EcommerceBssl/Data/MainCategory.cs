using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceBssl.Data
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
