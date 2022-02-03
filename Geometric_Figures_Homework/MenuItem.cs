namespace Geometric_Figures_Homework
{
    using System;

    public class MenuItem
    {
        private MenuItem(ConsoleKey consoleKey, MenuItemActions menuItemAction)
        {
            this.ConsoleKey = consoleKey;
            this.MenuItemAction = menuItemAction;
        }

        public static MenuItem ADD_SHAPE
        {
            get
            {
                return new MenuItem(ConsoleKey.F1, MenuItemActions.ADD_SHAPE_STR);
            }
        }

        public static MenuItem DELETE_SHAPE
        {
            get
            {
                return new MenuItem(ConsoleKey.F2, MenuItemActions.DELETE_SHAPE_STR);
            }
        }

        public static MenuItem EDIT_SHAPE
        {
            get
            {
                return new MenuItem(ConsoleKey.F3, MenuItemActions.EDIT_SHAPE_STR);
            }
        }

        public static MenuItem SORT_BY_AREA
        {
            get
            {
                return new MenuItem(ConsoleKey.F5, MenuItemActions.SORT_BY_AREA_STR);
            }
        }

        public static MenuItem SORT_BY_CIRCUMFERENCE
        {
            get
            {
                return new MenuItem(ConsoleKey.F6, MenuItemActions.SORT_BY_CIRCUMFERENCE_STR);
            }
        }

        public static MenuItem TOGGLE_BOUNDING_BOX
        {
            get
            {
                return new MenuItem(ConsoleKey.F9, MenuItemActions.TOGGLE_BOUNDING_BOX_STR);
            }
        }

        public static MenuItem TOGGLE_RENDERING
        {
            get
            {
                return new MenuItem(ConsoleKey.F10, MenuItemActions.TOGGLE_RENDERING_STR);
            }
        }

        public static MenuItem EXIT
        {
            get
            {
                return new MenuItem(ConsoleKey.F12, MenuItemActions.EXIT_STR);
            }
        }

        public static MenuItem BLANK
        {
            get
            {
                return new MenuItem(ConsoleKey.Enter, MenuItemActions.BLANK_STR);
            }
        }

        public static MenuItem ADD_CIRCLE
        {
            get
            {
                return new MenuItem(ConsoleKey.F1, MenuItemActions.ADD_CIRCLE_STR);
            }
        }

        public static MenuItem ADD_RECTANGLE
        {
            get
            {
                return new MenuItem(ConsoleKey.F2, MenuItemActions.ADD_RECTANGLE_STR);
            }
        }

        public static MenuItem ADD_TRIANGLE
        {
            get
            {
                return new MenuItem(ConsoleKey.F3, MenuItemActions.ADD_TRIANGLE_STR);
            }
        }

        public static MenuItem BACK_TO_MAIN_MENU
        {
            get
            {
                return new MenuItem(ConsoleKey.F4, MenuItemActions.BACK_TO_MAIN_MENU_STR);
            }
        }

        public ConsoleKey ConsoleKey
        {
            get; private set;
        }

        public MenuItemActions MenuItemAction
        {
            get;
        }

        public static string MenuItemActionToString(MenuItemActions menuItemAction)
        {
            switch (menuItemAction)
            {
                case MenuItemActions.ADD_SHAPE_STR:
                    return " F1 Add shape ";
                case MenuItemActions.DELETE_SHAPE_STR:
                    return " F2 Delete shape ";
                case MenuItemActions.EDIT_SHAPE_STR:
                    return " F3 Edit shape ";
                case MenuItemActions.SORT_BY_AREA_STR:
                    return " F5 Sort by area ";
                case MenuItemActions.SORT_BY_CIRCUMFERENCE_STR:
                    return " F6 Sort by circumference ";
                case MenuItemActions.TOGGLE_BOUNDING_BOX_STR:
                    return " F9 Toggle boundingbox ";
                case MenuItemActions.TOGGLE_RENDERING_STR:
                    return " F10 Toggle rendering ";
                case MenuItemActions.EXIT_STR:
                    return " F12 Exit ";
                case MenuItemActions.BLANK_STR:
                    return string.Empty;
                case MenuItemActions.ADD_CIRCLE_STR:
                    return " F1 Add circle ";
                case MenuItemActions.ADD_RECTANGLE_STR:
                    return " F2 Add rectangle ";
                case MenuItemActions.ADD_TRIANGLE_STR:
                    return " F3 Add triangle ";
                case MenuItemActions.BACK_TO_MAIN_MENU_STR:
                    return " F4 Back to main menu ";
                default: return string.Empty;
            }
        }
    }
}