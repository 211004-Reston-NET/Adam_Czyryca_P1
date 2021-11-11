namespace TTGUI
{
    public interface IFactory
    {
        /// <summary>
        /// Will give a derived/child class from IMenu interface based on enum MenuType
        /// </summary>
        /// <param name="p_menu"></param>
        /// <returns>Returns derived/child class from IMenu</returns>
        IMenu GetMenu(MenuType p_menu);
    }
}