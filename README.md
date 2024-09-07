# 🏷️ Inventory Management System

An ASP.NET Core MVC project for managing products in an inventory system. This application uses Dapper for data access and provides a set of features to manage products and their categories.

## ✨ Features

- 👀 View a list of all products.
- 📦 View details of a single product.
- ✏️ Update product information.
- ➕ Insert new products into the inventory.
- ❌ Delete products from the inventory.
- 🔍 Find products based on categories.
- 🏆 View the best-selling product.

## 🛠️ Technologies Used

- **ASP.NET Core MVC**: Framework for building the web application.
- **Dapper**: Micro ORM for data access.
- **SQL**: Database operations are performed using SQL queries.

### Product Management

- **View All Products**: Navigate to `/Product/Index` to see a list of all products.
- **View Product Details**: Navigate to `/Product/ViewProduct/{id}` where `{id}` is the ID of the product.
- **Update Product**: Navigate to `/Product/UpdateProduct/{id}` to edit a product's details.
- **Insert New Product**: Navigate to `/Product/InsertProduct` to add a new product to the inventory.
- **Delete Product**: Products can be deleted from the list view or by navigating to the product's details page.

### Special Features

- **Find Products**: Navigate to `/Product/FindAProduct` to search for products based on categories.
- **Best Selling Product**: Navigate to `/Product/BestSellingProduct` to view the product with the highest sales.

## 🔗 API Endpoints

| Method | Endpoint                          | Description                           |
|--------|-----------------------------------|---------------------------------------|
| GET    | /Product/Index                     | List all products                     |
| GET    | /Product/ViewProduct/{id}          | View details of a single product      |
| GET    | /Product/UpdateProduct/{id}        | Edit details of a product             |
| POST   | /Product/UpdateProductToDatabase   | Update product details in the database |
| GET    | /Product/InsertProduct             | Form to insert a new product           |
| POST   | /Product/InsertProductToDatabase   | Insert a new product into the database |
| POST   | /Product/DeleteProduct             | Delete a product from the database    |
| GET    | /Product/FindAProduct              | Find products based on categories     |
| GET    | /Product/BestSellingProduct        | View the best-selling product         |

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. **Fork the repository** and clone it to your local machine.
2. **Create a new branch** for your feature or bug fix.
3. **Make your changes** and ensure they are well-tested.
4. **Submit a pull request** with a clear description of your changes.

## 📜 License

This project is licensed under the [MIT License](LICENSE).
