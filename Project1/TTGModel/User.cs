using System;
namespace TTGModel
{
    public class User
    {
        /*properties:
         name
         address
         email/phone number
        */

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailPhone { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nEmail/Phone: {EmailPhone}";
        }
    }
}