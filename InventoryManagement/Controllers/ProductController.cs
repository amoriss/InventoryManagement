using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers;
public class ProductController : Controller
{
    private readonly IProductRepository repo;
    public ProductController(IProductRepository repo)
    {
        this.repo = repo;
    }

    // GET: /<controller>/
    public IActionResult Index()
    {
        var products = repo.GetAllProducts();

        return View(products);
    }

    public IActionResult ViewProduct(int id)
    {
        var product = repo.GetProduct(id);

        return View(product);
    }

    public IActionResult UpdateProduct(int id)
    {
        Product prod = repo.GetProduct(id);

        if (prod == null)
        {
            return View("ProductNotFound");
        }

        return View(prod);
    }

    public IActionResult UpdateProductToDatabase(Product product)
    {
        repo.UpdateProduct(product);

        return RedirectToAction("ViewProduct", new { id = product.ProductId });
    }
    public IActionResult InsertProduct()
    {
        // var prod = repo.AssignCategory();
        //
        // return View(prod);
        var categories = repo.GetCategories(); // Fetch categories from the repository
        var product = new Product
        {
            Categories = categories // Assign categories to the product model
        };

        return View(product);
    }

    public IActionResult InsertProductToDatabase(Product productToInsert)
    {
        repo.InsertProduct(productToInsert);

        return RedirectToAction("Index");
    }

    public IActionResult DeleteProduct(Product product)
    {
        repo.DeleteProduct(product);

        return RedirectToAction("Index");
    }

    public IActionResult FindAProduct()
    {
        var products = repo.GetAllProducts();

        return View(products);
    }
    public IActionResult BestSellingProduct()
    {
        var product = repo.GetBestSellingProduct();

        return View(product);
    }

}
