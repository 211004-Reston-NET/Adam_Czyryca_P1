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

        /// <summary>
        /// delete the LineItem with the passed Id
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
         LineItem DeleteItem(LineItem _item);


        /// <summary>
        /// updates all items to to matched passed LineItem
        /// </summary>
        /// <param name="_item"></param>
        void Update(LineItem _item);

        /// <summary>
        /// This Method will update the stock of a given LineItem (p_lineItem.LineItemId) to the quantity provided (p_lineItem.Quantity)
        /// </summary>
        /// /// <param name="p_lineItem"> this is the ID for the LineItem that will be updated. </param>
        void RefreshStock(LineItem p_lineItem);

        LineItem GetMatchingLineItem(int _itemID);

        LineItem GetLineItemsById(int p_lineItemId);

        //Tuple<LineItem, Product> GetFullItem(LineItem _item);
    }
}