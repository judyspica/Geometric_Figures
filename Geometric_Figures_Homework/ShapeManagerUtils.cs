namespace Geometric_Figures_Homework
{
    using System;

    public class ShapeManagerUtils
    {
        public static int GetIntInputFromUser(string value, int minInclusive, int maxExclusive)
        {
            Console.WriteLine($"Enter the desired {value} integer: ");
            int userSelectedNumber = -1;
            do
            {
                bool parseSuccessful = int.TryParse(Console.ReadLine(), out userSelectedNumber);
                if (!parseSuccessful || userSelectedNumber < minInclusive || userSelectedNumber >= maxExclusive)
                {
                    userSelectedNumber = -1;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number!");
                    Console.ResetColor();
                }

                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            }
            while (userSelectedNumber == -1);
            return userSelectedNumber;
        }

        public static string GetCharInputFromUser(string value)
        {
            string desiredChar;
            do
            {
                Console.Write($"Enter the desired {value} character:  ");
                desiredChar = Console.ReadLine();

                if (desiredChar.Length > 1 || desiredChar == string.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. please input any printable character once!)");
                    Console.ResetColor();
                }

                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            }
            while (desiredChar.Length > 1 || desiredChar == string.Empty);
            return desiredChar;
        }

        public static ConsoleColor GetColorSelectionFromUser(string propertyColor, string shapeParameter)
        {
            string header = $"Please select the {propertyColor} of the {shapeParameter} charachter";
            return ReadUserColor(header);
        }

        public static Orientation PickOrientation()
        {
            int index = EnterValidInt();
            return MapToOrientation(index);
        }

        public static void ShowEditSuccessMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Info changed, you can press ESCAPE to return to main menu or press anything to keep on editing!");
            Console.ResetColor();
        }

        private static ConsoleColor ReadUserColor(string header)
        {
            int selectedIndex = ReadUserSelectedColor(header);
            return MapSelectedIndexToCosoleColor(selectedIndex);
        }

        private static int ReadUserSelectedColor(string header)
        {
            string[] colors = { "Black", "White", "Red", "Green", "Blue", "Yellow", "Magenta", "Cyan" };
            ConsoleKey keyPressed;
            int selectedIndex = 0;

            do
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                DisplayColorMenu(colors, header, selectedIndex);

                keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = colors.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == colors.Length)
                    {
                        selectedIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();
            return selectedIndex;
        }

        private static ConsoleColor MapSelectedIndexToCosoleColor(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    return ConsoleColor.Black;
                case 1:
                    return ConsoleColor.White;
                case 2:
                    return ConsoleColor.Red;
                case 3:
                    return ConsoleColor.Green;
                case 4:
                    return ConsoleColor.Blue;
                case 5:
                    return ConsoleColor.Yellow;
                case 6:
                    return ConsoleColor.Magenta;
                case 7:
                    return ConsoleColor.Cyan;
                default:
                    return ConsoleColor.White;
            }
        }

        private static void DisplayColorMenu(string[] colors, string header, int selectedIndex)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();
            Console.WriteLine(header);
            for (int index = 0; index < colors.Length; index++)
            {
                PrintColor(colors[index], index == selectedIndex);
            }

            Console.ResetColor();
        }

        private static void PrintColor(string color, bool isSelectedIndex)
        {
            if (isSelectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"  {color}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"   {color}");
            }
        }

        private static int EnterValidInt()
        {
            Console.WriteLine("Please Pick the Triangle Orientation: Options are: \nCorner bottom left (0)\nCorner bottom right (1)\nCorner top left (2)\nCorner top right (3)");
            int index;
            do
            {
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 4)
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter in between the choices");
                Console.ResetColor();
            }
            while (true);

            return index;
        }

        private static Orientation MapToOrientation(int index)
        {
            switch (index)
            {
                case 0: return Orientation.CORNER_BOTTOM_LEFT;
                case 1: return Orientation.CORNER_BOTTOM_RIGHT;
                case 2: return Orientation.CORNER_TOP_LEFT;
                case 3: return Orientation.CORNER_TOP_RIGHT;
                default: return Orientation.CORNER_BOTTOM_LEFT;
            }
        }
    }
}