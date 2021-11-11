using System.Collections.Generic;
using System.Linq;
using TTGDL;
using TTGModel;


namespace TTGBL
{
    public class StoreBL : IStoreBL
    {
        private IStoreRepository _repo;
        

        public StoreBL(IStoreRepository p_repo)
        {
            _repo = p_repo;
        }

        public Store AddStore(Store p_store)
        {
            return _repo.AddStore(p_store);
        }

        public List<Store> GetAllStores()
        {
            List<Store> listOfStores = _repo.GetAllStores();
            for (int i = 0; i < listOfStores.Count; i++)
            {
                listOfStores[i].Name = listOfStores[i].Name.ToUpper();
            }
            return listOfStores;
        }

        public List<Store> GetStore(string p_storeName)
        {
            List<Store> listOfStores = _repo.GetAllStores();

            //Select method will give a list of boolean if the condition was true/false
            //Where method will give the actual element itself based on some condition
            //ToList method will convert into List that our method currently needs to return.
            //ToLower will lowercase the string to make it not case sensitive
            return listOfStores.Where(store => store.Name.ToLower().Contains(p_storeName.ToLower())).ToList();

        }

        public Store GetStoreById(int p_storeId)
        {
            return _repo.GetStoreById(p_storeId);
        }
    }
}
