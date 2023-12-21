using System;
using System.Collections.Generic;

namespace RegistrationLogin.Models
{
    public partial class ProductModel
    {
        public ProductModel()
        {
            Products = new HashSet<Product>();
        }

        public int ProductModelId { get; set; }
        public string? ProductModelName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
