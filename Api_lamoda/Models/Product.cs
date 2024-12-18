using System;
using System.Collections.Generic;

namespace Api_lamoda.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int BrandId { get; set; }

    public DateTime DateAdded { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
