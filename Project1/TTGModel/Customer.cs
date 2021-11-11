using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TTGModel
{
    public class Customer
    {
        /*properties:
         name
         address
         email/phone number
         list of orders
        */
        public int Id { get; set; }
        //public string Name { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (!Regex.IsMatch(value, @"[A-Za-z .]+$"))
                {
                    throw new Exception("only letters");
                }
                _name = value;
            }
        }
        
        public string Address { get; set; }
        public string EmailPhone { get; set; }

        public List<LineItem> OrderList { get; set; }
        public List<Orders> Orders { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nAddress: {Address}\nEmail/Phone: {EmailPhone}";
        }
    }
}