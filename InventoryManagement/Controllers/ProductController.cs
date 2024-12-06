using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
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
        var categories = repo.GetCategories();

        var viewModel = new ProductsListViewModel()
        {
            Products = products,
            Categories = categories
        };

        return View(viewModel);
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
        var prod = repo.AssignCategory();

        return View(prod);
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
        var categories = repo.GetCategories();

        var viewModel = new ProductsListViewModel()
        {
            Products = products,
            Categories = categories
        };

        return View(viewModel);
    }

    public IActionResult BestSellingProduct()
    {
        var product = repo.GetBestSellingProduct();

        return View(product);
    }

    public IActionResult Shop()
    {
        var products = repo.GetAllProducts();
        var categories = repo.GetCategories();

        var viewModel = new ProductsListViewModel()
        {
            Products = products,
            Categories = categories
        };

        return View(viewModel);
    }

    public IActionResult ViewCart()
    {
        var cart = HttpContext.Session.Get<List<Product>>("Cart") ?? new List<Product>();
        return View(cart);
    }

    public IActionResult RemoveFromCart(int productId)
    {
        var cart = HttpContext.Session.Get<List<Product>>("Cart") ?? new List<Product>();

        var productToRemove = cart.FirstOrDefault(p => p.ProductId == productId);
        if (productToRemove != null)
        {

            cart.Remove(productToRemove);
        }

        HttpContext.Session.Set("Cart", cart);
        return RedirectToAction("ViewCart");
    }
}