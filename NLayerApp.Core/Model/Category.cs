using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core.Model
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        //Bir kategorinin birden fazla ürünü olabilir.
        public ICollection<Product> Products { get; set; }
    }
}
