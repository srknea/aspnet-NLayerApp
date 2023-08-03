using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } 
        public int Stock { get; set; }
        public decimal Price { get; set; }


        //Bir ürünün bir kategorisi olabilir.
        public int CategoryId { get; set; } //foreign key
        public Category Category { get; set; }

        public ProductFeature productFeature { get; set; }
    }
}
