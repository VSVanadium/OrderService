using Service;

namespace OrderService.Data
{
    public class Products
    {

        public static List<Service.Product> GetProducts()
        {
            
            List<Product> products = new List<Product>()
            {
                new Product { Id = 1,Name ="Handcrafted Rubber Ball", Price = (float)5.0m },
                new Product { Id = 2,Name ="Handmade Soft Keyboard", Price = (float)8.9m },
                new Product { Id = 3,Name ="Gorgeous Concrete Chicken", Price = (float)10.5m },
                new Product { Id = 4,Name ="Rustic Metal Tuna", Price = (float)3.4m },
                new Product { Id = 5,Name ="Generic Soft Shirt", Price = (float)78.5m }
            };


            return products;
        }
    }
}
