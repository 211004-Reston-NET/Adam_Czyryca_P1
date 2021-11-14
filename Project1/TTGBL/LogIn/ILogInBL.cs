using System;
using TTGModel;

namespace TTGBL
{
    public interface ILogInBL
    {
        /// <summary>
        /// will return true if a customer in the database is found containing 
        /// the same data as the passed parameters
        /// </summary>
        /// <param name="p_custName"></param>
        /// <param name="p_custEmailPhone"></param>
        /// <returns></returns>
        Boolean VerifyCustomerID(string p_custName, string p_custEmailPhone);

        
    }
}