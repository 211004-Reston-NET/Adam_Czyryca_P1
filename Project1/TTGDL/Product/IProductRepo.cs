using System.Collections.Generic;
using TTGModel;

namespace TTGDL
{
    public interface IProductRepo
    {
        /// <summary>
        /// will add a new product to the database
        /// </summary>
        /// <param name="_prod"></param>
        /// <returns></returns>
        Product AddProduct(Product _prod);

        /// <summary>
        /// will retrive a list of all products 
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// will find the product with the passed id
        /// </summary>
        /// <param name="p_prodID"></param>
        /// <returns></returns>
        Product GetProductByID(int p_prodID);
    }
}