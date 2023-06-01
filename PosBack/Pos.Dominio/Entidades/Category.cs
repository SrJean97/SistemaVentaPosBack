using System;
using System.Collections.Generic;

namespace Pos.Dominio.Entidades
{
    public partial class Category : EntidadBase
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
