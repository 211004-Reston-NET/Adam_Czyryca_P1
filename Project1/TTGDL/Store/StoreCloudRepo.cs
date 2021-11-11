using System.Collections.Generic;
using System.Linq;
using TTGModel;


namespace TTGDL
{
    public class StoreCloudRepo : IStoreRepository
    {
        private database1Context _context;

        public StoreCloudRepo(database1Context p_context)
        {
            _context = p_context;
        }

        public Store AddStore(Store p_store)
        {
            _context.Stores.Add(p_store);
            
            _context.SaveChanges();
            return p_store;
        }


        public List<Store> GetAllStores()
        {
            
            return _context.Stores.ToList();
        }

        public Store GetStoreById(int p_storeId)
        {
            var result = _context.Stores
                 .FirstOrDefault<Store>(store =>
                     store.Id == p_storeId);
            return new Store()
            {
                Id = result.Id,
                Name = result.Name,
                Address = result.Address,
            }; 
        }
    }
}