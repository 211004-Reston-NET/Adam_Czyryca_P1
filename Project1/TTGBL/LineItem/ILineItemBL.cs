using System;
using System.Collections.Generic;
using TTGModel;
namespace TTGBL
{
    public interface ILineItemBL
    {
        /// <summary>
        /// this will return a list of LineItemss LineItemsd in the database
        /// it will alse capitalize the LineItems name
        /// </summary>
        /// <returns></returns>
        List<LineItem> GetAllLineItems();

        /// <summary>
        /// get all line items at designated store
        /// </summary>
        /// <param name="_storeId"></param>
        /// <returns></returns>
        List<LineItem> GetAllLineItems(int _storeId);

        /// <summary>
        /// add line item 
        /// </summary>
        /// <param name="p_LineItem"></param>
        /// <param name="ProdName"></param>
        /// <param name="StoreName"></param>
        /// <returns></returns>
        LineItem AddLineItem(LineItem p_LineItem);

        /// <summary>
        /// updates the quantity of the lineItem with the passed id
        /// </summary>
        /// <param name="_itemID"></param>
        /// <param name="_newQuantity"></param>
        /// <returns></returns>
        void UpdateQuantity(int _itemID, int _newQuantity);


        /// <summary>
        /// updates all items to to matched passed LineItem
        /// </summary>

        /// <param name="_item"></param>
        void Update(LineItem _item);


        /// <summary>
        /// delete the LineItem with the passed Id
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        LineItem DeleteItem(LineItem _item);
        LineItem GetMatchingLineItem(int _itemID);

        /// <summary>
        /// This Method will update the stock of a given LineItem (p_lineItem.LineItemId) to the quantity provided (p_lineItem.Quantity)
        /// </summary>
        /// /// <param name="p_lineItem"> this is the ID for the LineItem that will be updated. </param>
        void RefreshStock(LineItem p_lineItem);


        LineItem GetLineItemsById(int p_lineItemId);
    }
}