using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace InventoryManagement.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public int OnSale { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Stock Level must be 1 or greater.")]
    public int StockLevel { get; set; }

    public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    public byte[] ImageData { get; set; }
}