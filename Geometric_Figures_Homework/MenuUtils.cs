namespace Geometric_Figures_Homework
{
    using System;

    public class MenuUtils
    {
        public static Menu CreateMainMenu()
        {
            Menu menu = new Menu(true);

            menu.AddMenuItem(MenuItem.ADD_SHAPE);
            menu.AddMenuItem(MenuItem.DELETE_SHAPE);
            menu.AddMenuItem(MenuItem.EDIT_SHAPE);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.SORT_BY_AREA);
            menu.AddMenuItem(MenuItem.SORT_BY_CIRCUMFERENCE);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.TOGGLE_BOUNDING_BOX);
            menu.AddMenuItem(MenuItem.TOGGLE_RENDERING);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.EXIT);

            return menu;
        }

        public static Menu CreateAddShapeMenu()
        {
            Menu menu = new Menu(false);

            menu.AddMenuItem(MenuItem.ADD_CIRCLE);
            menu.AddMenuItem(MenuItem.ADD_RECTANGLE);
            menu.AddMenuItem(MenuItem.ADD_TRIANGLE);
            menu.AddMenuItem(MenuItem.BACK_TO_MAIN_MENU);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.BLANK);
            menu.AddMenuItem(MenuItem.BLANK);

            return menu;
        }
    }
}