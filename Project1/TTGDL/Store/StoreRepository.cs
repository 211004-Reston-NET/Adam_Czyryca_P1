using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TTGModel;

namespace TTGDL
{
    public class StoreRepository : IStoreRepository
    {
        //reference to database
        private const string _filePath = "./../TTGDL/Database/Store.json";
        private string _jsonString;

        public Store AddStore(Store p_store)
        {
            //take all stores bc they will be overwriten 
            List<Store> listOfStores = GetAllStores();
            //added the new store that was passed
            listOfStores.Add(p_store);

            _jsonString = JsonSerializer.Serialize(listOfStores, new JsonSerializerOptions{WriteIndented=true});

            //add the store.jason
            File.WriteAllText(_filePath,_jsonString);

            return p_store;
        }

        public List<Store> GetAllStores()
        {
            _jsonString = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<Store>>(_jsonString);
        }

        public Store GetStoreById(int _storeId)
        {
            throw new NotImplementedException();
        }
    }
}
