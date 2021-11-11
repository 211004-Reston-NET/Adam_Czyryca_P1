using TTGModel;

namespace TTGWebUI.Models
{
    public class StoreVM
    {
        public StoreVM()
        {

        }
        public StoreVM(Store p_cust)
        {
            this.Id = p_cust.Id;
            this.Name = p_cust.Name;
            this.Address = p_cust.Address;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
