using System.Collections.Generic;
using System.Linq;
using TTGModel;


namespace TTGDL
{
    public class ProductCloudRepo : IProductRepo
    {
        private database1Context _context;

        public ProductCloudRepo(database1Context p_context)
        {
            _context = p_context;
        }

        public Product AddProduct(Product p_Product)
        {
            _context.Products.Add(p_Product);
            
            _context.SaveChanges();
            return p_Product;
        }


        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }


        public Product GetProductByID(int p_prodID)
        {
            var result = _context.Products
                .FirstOrDefault<Product>(prod =>
                    prod.Id == p_prodID);
            return new Product()
            {
                Id = result.Id,
                Name = result.Name,
                Price = result.Price,
                Description = result.Description,
                Catagory = result.Catagory
            };
        }
    }
}