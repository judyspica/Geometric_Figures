namespace Geometric_Figures_Homework
{
    using System;

    public class ShapesEngine
    {
        private static readonly int NOTSET = -1;
        private readonly ShapeManager shapeManager;
        private bool applicationRunning;
        private bool boundingBoxActive;
        private bool renderingActive;

        public ShapesEngine()
        {
            this.shapeManager = new ShapeManager();

            this.applicationRunning = true;
            this.boundingBoxActive = false;
            this.renderingActive = false;
        }

        public void Start()
        {
            Menu menu = MenuUtils.CreateMainMenu();
            do
            {
                this.RenderScreen(menu);
                int selectedIndex = this.ReadIndexFromUser();
                MenuItemActions action = menu.GetMenuItems()[selectedIndex].MenuItemAction;
                menu = this.HandleAction(action);
            }
            while (this.applicationRunning);
        }

        private void RenderScreen(Menu menu)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();
            Console.ResetColor();
            if (menu.ShowsShapesInMenu())
            {
                this.shapeManager.RenderShapes(this.boundingBoxActive, this.renderingActive);
            }

            menu.Render();
        }

        private Menu HandleAction(MenuItemActions action)
        {
            switch (action)
            {
                case MenuItemActions.ADD_SHAPE_STR:
                    return MenuUtils.CreateAddShapeMenu();
                case MenuItemActions.DELETE_SHAPE_STR:
                    this.shapeManager.DeleteShape();
                    return MenuUtils.CreateMainMenu();
                case MenuItemActions.EDIT_SHAPE_STR:
                    this.shapeManager.EditShap();
                    return MenuUtils.CreateMainMenu();
                case MenuItemActions.SORT_BY_AREA_STR:
                    this.shapeManager.SortByArea();
                    return MenuUtils.CreateMainMenu();
                case MenuItemActions.SORT_BY_CIRCUMFERENCE_STR:
                    this.shapeManager.SortByCircumference();
                    return MenuUtils.CreateMainMenu();
                case MenuItemActions.TOGGLE_BOUNDING_BOX_STR:
                    this.boundingBoxActive = !this.boundingBoxActive;
                    return MenuUtils.CreateMainMenu();
                case MenuItemActions.TOGGLE_RENDERING_STR:
                    this.renderingActive = !this.renderingActive;
                    return MenuUtils.CreateMainMenu();
                case MenuItemActions.EXIT_STR:
                    this.ResetConsoleSize();
                    this.applicationRunning = false;
                    return MenuUtils.CreateMainMenu();

                case MenuItemActions.ADD_CIRCLE_STR:
                    this.shapeManager.AddCircle();
                    return MenuUtils.CreateMainMenu();
                case MenuItemActions.ADD_RECTANGLE_STR:
                    this.shapeManager.AddRectangle();
                    return MenuUtils.CreateMainMenu();
                case MenuItemActions.ADD_TRIANGLE_STR:
                    this.shapeManager.AddTriangle();
                    return MenuUtils.CreateMainMenu();
                case MenuItemActions.BACK_TO_MAIN_MENU_STR:
                    return MenuUtils.CreateMainMenu();
                default:
                    return MenuUtils.CreateMainMenu();
            }
        }

        private void ResetConsoleSize()
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 120;
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);
        }

        private int ReadIndexFromUser()
        {
            int selectedIndex;
            bool selectedIndexSet;

            do
            {
                selectedIndex = this.MapUserKeyPressedToIndex();
                selectedIndexSet = selectedIndex != NOTSET;
            }
            while (!selectedIndexSet);
            return selectedIndex;
        }

        private int MapUserKeyPressedToIndex()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.F1: return 0;
                case ConsoleKey.F2: return 1;
                case ConsoleKey.F3: return 2;
                case ConsoleKey.F4: return 3;
                case ConsoleKey.F5: return 4;
                case ConsoleKey.F6: return 5;
                case ConsoleKey.F7: return 6;
                case ConsoleKey.F8: return 7;
                case ConsoleKey.F9: return 8;
                case ConsoleKey.F10: return 9;
                case ConsoleKey.F11: return 10;
                case ConsoleKey.F12: return 11;
                default: return NOTSET;
            }
        }
    }
}