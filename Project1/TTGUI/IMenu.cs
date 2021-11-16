namespace TTGUI
{
    public enum MenuType
    {
        MainMenu,
        MainCustomerMenu,
        ManagerLogInMenu,
        TestingMenu,
        StoreMenu,
        CustomerMenu,
        LineItemMenu,
        OrdersMenu,
        ProductMenu,
        CurrentCustomer,
        CurrentProduct,
        CurrentOrder,
        CurrentStore,
        CurrentLineItem,
        AddStoreMenu,
        AddCustomerMenu,
        AddOrderMenu,
        AddProductsMenu,
        AddLineItemsMenu,
        AddItemsToOrder,
        ShowStores,
        ShowCustomers,
        ShowProducts,
        ShowLineItems,
        ShowStoreInventory,
        ShowOrders,
        LogInMenu,
        test,
        Exit
    }

    public interface IMenu
    {
        /// <summary>
        /// display navigation menu for the respective class.
        /// </summary>
        void Menu();

        /// <summary>
        /// takes user choice to navigate between menus
        /// </summary>
        MenuType Navigation();
    }




}