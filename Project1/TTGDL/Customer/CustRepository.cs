using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TTGModel;

namespace TTGDL
{
    public class CustRepository //: ICustRepository
    {
        //the path to the teporary DB that is the json file 
        private const string _filePath = "./../TTGDL/Database/Customer.json";
        private string _jsonString;
        public Customer AddCustomer(Customer cust)
        {
            //get a list of customer objects via GetAllCustomers() from the json file 
            List<Customer> ListOfCustomers = GetAllCustomers();
            //add the passed customer obj to the ListOfCustomers retrived in line 14
            ListOfCustomers.Add(cust);
            //convert ListOfCustomers into a string named _jsonString so it can be stored
            _jsonString = JsonSerializer.Serialize(ListOfCustomers, new JsonSerializerOptions{WriteIndented=true});
            //write to the json file
            File.WriteAllText(_filePath,_jsonString);

            return cust;
        }

        public List<Customer> GetAllCustomers()
        {
            //read the data stored in the jasonfile to the string _jasonString
            _jsonString = File.ReadAllText(_filePath);

            //convert _jasonString to a readable format then return  
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }
    }
}