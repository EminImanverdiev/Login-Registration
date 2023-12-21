using System;
using System.Collections.Generic;

namespace RegistrationLogin.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductModelId { get; set; }
        public DateTime? ProductEnteredDate { get; set; }
        public bool? ProductActivity { get; set; }

        public virtual ProductModel? ProductModel { get; set; }
    }
}
