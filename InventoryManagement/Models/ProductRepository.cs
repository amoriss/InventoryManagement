﻿using Dapper;
using System.Data;

namespace InventoryManagement.Models;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;

    public ProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM Products;");
    }

    public Product GetProduct(int id)
    {
        return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
            new { id = id });
    }

    public void UpdateProduct(Product product) 
    {
        _conn.Execute(
            "UPDATE products SET Name = @name, Price = @price, CategoryID = @categoryId, OnSale = @onSale, StockLevel = @stockLevel WHERE ProductID = @id",
            new
            {
                name = product.Name, price = product.Price, categoryId = product.CategoryId, onSale = product.OnSale,
                stockLevel = product.StockLevel, id = product.ProductId
            });
    }

    public void InsertProduct(Product productToInsert)
    {
        _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
            new
            {
                name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryId
            });
    }

    public IEnumerable<Category> GetCategories()
    {
        return _conn.Query<Category>("SELECT * FROM categories;");
    }

    public Product AssignCategory()
    {
        var categoryList = GetCategories();
        var product = new Product
        {
            Categories = categoryList
        };

        return product;
    }

    public void DeleteProduct(Product product)
    {
        _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;",
            new { id = product.ProductId });
        _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",
            new { id = product.ProductId });
        _conn.Execute("DELETE FROM Products WHERE ProductID = @id;",
            new { id = product.ProductId });
    }

    public Product GetBestSellingProduct()
    {
        return _conn.QuerySingleOrDefault<Product>("CALL GetBestSellingProduct();");
    }
}