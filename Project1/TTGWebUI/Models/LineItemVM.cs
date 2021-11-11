using TTGModel;

namespace TTGWebUI.Models
{
    public class LineItemVM
    {

        public LineItemVM()
        {

        }

        public LineItemVM(LineItem p_item)
        {
            this.Id = p_item.Id;
            this.Quantity = p_item.Quantity;
            this.Product = p_item.Product;
            this.Store = p_item.Store;
            // this.Name = p_item.Productobj.Name;
            // this.Price = p_item.Productobj.Price;
            // this.Category = p_item.Productobj.Catagory;
            // this.Description = p_item.Productobj.Description;
        }


        public int Id { get; set; }
        public int Quantity  { get; set; }
        public int Product { get; set; }
        public int Store { get; set; }
        // public string Name { get; set; }
        // public double Price { get; set; }
        // public string Description { get; set; }
        // public string Category { get; set; }


    }
}
