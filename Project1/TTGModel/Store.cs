using System.Collections.Generic;
namespace TTGModel
{
    public class Store
    {


        public int Id { get; set; }
        public string Name { get; set; }

        /*
        if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
        {
            throw new Exception("Name can only hold letters!");
        }
        */
        public string Address{get; set;}

        public List<LineItem> LineItems { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Orders> Orders { get; set; }


        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nAddress: {Address}";
        }
    }
}
