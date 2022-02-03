namespace Geometric_Figures_Homework
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.CursorVisible = false;
            ShapesEngine shapesEngine = new ShapesEngine();
            shapesEngine.Start();
        }
    }
}
