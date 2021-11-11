using System;
using System.Collections.Generic;
using TTGModel;
namespace TTGDL
{
    public interface ILineItemRepo
    {
        /// <summary>
        /// this will return a list of stores stored in the database
        /// it will alse capitalize the store name
        /// </summary>
        /// <returns></returns>
        List<LineItem> GetAllLineItems();

        /// <summary>
        /// set all line items in a designated store
        /// </summary>
        /// <param name="_storeId"></param>
        /// <returns></returns>
        List<LineItem> GetAllLineItems(int _storeId);

        /// <summary>
        /// adds line item with refence to the product and string 
        /// </summary>
        /// <param name="_LineItem"></param>
        /// <param name="ProdName"></param>
        /// <param name="StoreName"></param>
        /// <returns></returns>
        LineItem AddLineItem(LineItem _LineItem);

        /// <summary>
        /// updates the quantity of the lineItem with the passed id
        /// </summary>
        /// <param name="_itemID"></param>
        /// <param name="_newQuantity"></param>
        /// <returns></returns>
        void UpdateQuantity(int _itemID, int _newQuantity);

        LineItem GetMatchingLineItem(int _itemID);

        //Tuple<LineItem, Product> GetFullItem(LineItem _item);
    }
}