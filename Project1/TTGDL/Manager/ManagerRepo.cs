using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TTGModel;

namespace TTGDL
{
    class ManagerRepo : IManagerRepo
    {
        private const string _filePath = "./../TTGDL/Database/Manager.json";

        string _JsonString;


        public Manager AddCustomer(Manager manager)
        {
            List<Manager> ListOfManagers = GetAllManagers();

            ListOfManagers.Add(manager);

            JsonSerializer.Serialize(ListOfManagers, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(_filePath, _JsonString);

            return manager;
        }

        public List<Manager> GetAllManagers()
        {
            _JsonString = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<Manager>>(_JsonString);
        }
    }
}