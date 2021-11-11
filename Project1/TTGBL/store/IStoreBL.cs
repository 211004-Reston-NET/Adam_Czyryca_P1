using System.Collections.Generic;
using TTGModel;
namespace TTGBL
{
    public interface IStoreBL
    {
        /// <summary>
        /// this will return a list of stores stored in the database
        /// it will alse capitalize the store name
        /// </summary>
        /// <returns></returns>
        List<Store> GetAllStores();

        /// <summary>
        /// adds a new store to the database
        /// </summary>
        /// <param name="p_store"></param>
        /// <returns></returns>
        Store AddStore(Store p_store);


        /// <summary>
        /// find a specific 
        /// </summary>
        /// <param name="p_storeName"></param>
        /// <returns></returns>
        List<Store> GetStore(string p_storeName);

        /// <summary>
        /// finds a store obj whos id matches the passed int
        /// </summary>
        /// <param name="_storeId"></param>
        /// <returns></returns>
        Store GetStoreById(int _storeId);

    }
}