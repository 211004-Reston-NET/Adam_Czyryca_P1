using System;
using System.Collections.Generic;
using TTGBL;
using TTGModel;

namespace TTGUI
{
    public class CurrentProduct : IMenu
    {
        private IProductBL _prodBL;

        public CurrentProduct(IProductBL p_prodBL)
        {
            _prodBL=p_prodBL;
        }
        public void Menu()
        {
            List<Product> ListOfProducts = _prodBL.GetProduct(SingletonProduct.product.Name);

            //Console.WriteLine(SingletonProduct.product.Name);
            Console.WriteLine("search result");
            foreach (Product Product in ListOfProducts)
            {
                Console.WriteLine(
                    "-------------------------\n"+
                    $"{Product}\n"+
                    "-------------------------\n"
                ); 
            }
            Console.WriteLine("[0] - Go back");
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    SingletonProduct.product.Name="";
                    return MenuType.ShowProducts;
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return MenuType.CurrentProduct;
            }
        }
    }
}