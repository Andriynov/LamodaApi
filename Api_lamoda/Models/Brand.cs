using System;
using System.Collections.Generic;

namespace Api_lamoda.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Website { get; set; }

    public DateTime DateAdded { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
