using System.Collections.Generic;
using TTGModel;

namespace TTGBL
{
    public interface IProductBL
    {
        /// <summary>
        /// get a list of all product obj in json file 
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// gets the product with an id matching the passed int  
        /// </summary>
        /// <param name="p_prodID"></param>
        /// <returns></returns>
        Product GetProductByID(int p_prodID);

        /// <summary>
        /// adds a singular product obj to the json file
        /// </summary>
        /// <param name="p_prod"></param>
        /// <returns></returns>
        Product AddProduct(Product p_prod);

        /// <summary>
        /// will return single product 
        /// </summary>
        /// <param name="p_prodName"></param>
        /// <returns></returns>
        List<Product> GetProduct(string p_prodName); 
    }
}