using TTGModel;

namespace TTGWebUI.Models
{
    public class ProductVM
    {
        public ProductVM()
        {

        }
        public ProductVM(Product p_prod)
        {
            this.Id = p_prod.Id;
            this.Name = p_prod.Name;
            this.Price = p_prod.Price;
            this.Description = p_prod.Description;
            this.Catagory = p_prod.Catagory;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Catagory { get; set; }

    }
}
