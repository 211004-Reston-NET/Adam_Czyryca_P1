using System.Collections.Generic;
using TTGModel;
using TTGDL;
using System;

namespace TTGBL
{
    public class LineItemBL : ILineItemBL
    {

        private ILineItemRepo _LineRepo;
       // private IProductRepo _prodRepo;

        public LineItemBL(ILineItemRepo p_Line)//,IProductRepo p_prodRepo)
        {
            _LineRepo = p_Line;
           // _prodRepo=p_prodRepo;
            
        }


        public LineItem AddLineItem(LineItem p_LineItem)
        {
            return _LineRepo.AddLineItem(p_LineItem);
        }

        public List<LineItem> GetAllLineItems()
        {
            List<LineItem> ListOfLineItems = _LineRepo.GetAllLineItems();

            return ListOfLineItems;
        }

        public List<LineItem> GetAllLineItems(int p_storeId)
        {
            List<LineItem> ListOfLineItems = _LineRepo.GetAllLineItems(p_storeId);

            return ListOfLineItems;
        }

        // public Tuple<LineItem, Product> GetFullItem(LineItem p_item)
        // {
        //     return _LineRepo.GetFullItem(p_item);
        // }

        public LineItem GetMatchingLineItem(int p_itemID)
        {
            return _LineRepo.GetMatchingLineItem(p_itemID);
        }

        public void UpdateQuantity(int p_itemID, int p_newQuantity)
        {
            _LineRepo.UpdateQuantity(p_itemID, p_newQuantity);
        }

    }
}