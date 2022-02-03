namespace Geometric_Figures_Homework
{
    using System;

    public abstract class GeometricFigure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string OuterChar { get; set; }
        public ConsoleColor OuterBackgroundColor { get; set; }
        public ConsoleColor OuterForgroundColor { get; set; }
        public string InnerChar { get; set; }
        public ConsoleColor InnerBackgroundColor { get; set; }
        public ConsoleColor InnerForgroundColor { get; set; }

        public abstract void Draw(bool boundingBoxActive, bool renderingActive);

        public abstract double CalculateArea();

        public abstract double CalculateCircumference();

        public abstract void PrintInfo(int index);

        public abstract void EditInfo();

        public string SelectAttributeToChange(params string[] attributes)
        {
            for (int index = 0; index < attributes.Length; index++)
            {
                Console.WriteLine($"Index {index}: {attributes[index]}");
            }

            int indexOfSelectedAttribute = ShapeManagerUtils.GetIntInputFromUser("attribute", 0, attributes.Length);
            return attributes[indexOfSelectedAttribute];
        }
    }
}