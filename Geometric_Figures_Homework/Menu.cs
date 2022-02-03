namespace Geometric_Figures_Homework
{
    using System;

    public class Menu
    {
        private readonly MenuItem[] menuItems;
        private readonly bool showShapesInMenu;
        private int itmesIndex;

        public Menu(bool showShapesInMenu)
        {
            this.menuItems = new MenuItem[12];
            this.showShapesInMenu = showShapesInMenu;
            this.itmesIndex = 0;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            this.menuItems[this.itmesIndex] = menuItem;
            this.itmesIndex++;
        }

        public void Render()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            for (int index = 0; index < this.itmesIndex; index++)
            {
                if (index == 3 || index == 6 || index == 7 || index == 10) 
                { 
                    continue; 
                }

                Console.Write("     ");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(MenuItem.MenuItemActionToString(this.menuItems[index].MenuItemAction));
                Console.ResetColor();
            }
        }

        public MenuItem[] GetMenuItems()
        {
            return this.menuItems;
        }

        public bool ShowsShapesInMenu()
        {
            return this.showShapesInMenu;
        }
    }
}