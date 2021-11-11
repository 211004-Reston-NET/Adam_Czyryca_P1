using System.Collections.Generic;
using TTGModel;
namespace TTGDL
{
    public interface IManagerRepo
    {
        /// <summary>
        /// will return a list of manager objects from the database
        /// </summary>
        /// <returns></returns>
        List<Manager> GetAllManagers();

        /// <summary>
        /// will add a manager obj to the database
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        Manager AddCustomer(Manager manager);
    }
}