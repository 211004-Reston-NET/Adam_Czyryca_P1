namespace TTGModel
{
    public class Manager : User
    {

        public int EmployeeId { get; set; }

        public int Store { get; set; }

        public Store StoreNavigation { get; set; }

    }
}