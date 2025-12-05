using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.Products
{

    public record UpdateProductRequest(string Name, decimal Price, int Stock);
}
