namespace Geometric_Figures_Homework
{
    using System;

    public class Circle : GeometricFigure
    {
        public int Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculateCircumference()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override void Draw(bool boundingBoxActive, bool renderingActive)
        {
            if (this.X >= Console.LargestWindowWidth || this.Y >= Console.LargestWindowHeight) 
            { 
                return; 
            }

            int currentY = this.Y;
            double rariusInside = this.Radius - 0.5;
            double radiusOutside = this.Radius + 0.5;

            Console.SetCursorPosition(this.X, currentY);

            for (double i = this.Radius; i >= -this.Radius; i--)
            {
                if (i == this.Radius % 2)
                {
                    continue;
                }

                for (double j = -this.Radius; j < radiusOutside; j++)
                {
                    if (Console.CursorLeft + 1 >= Console.LargestWindowWidth || Console.CursorTop + 1 >= Console.LargestWindowHeight) 
                    { 
                        continue; 
                    }

                    if (j == this.Radius % 2)
                    {
                        continue;
                    }

                    double valueSquared = (j * j) + (i * i);
                    if (valueSquared < radiusOutside * radiusOutside && valueSquared > rariusInside * rariusInside)
                    {
                        Console.ForegroundColor = this.OuterForgroundColor;
                        Console.BackgroundColor = this.OuterBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromColor();
                        }

                        Console.Write(this.OuterChar);
                        Console.ResetColor();
                    }
                    else if (valueSquared < this.Radius * this.Radius)
                    {
                        Console.ForegroundColor = this.InnerForgroundColor;
                        Console.BackgroundColor = this.InnerBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromColor();
                        }

                        Console.Write(this.InnerChar);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.SetCursorPosition(this.X, currentY++ + 1);
                Console.ResetColor();
            }

            if (boundingBoxActive)
            {
                this.DrawBoundingBoxOnTop();
            }
        }

        public override void PrintInfo(int index)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Circle @ index {index}: Radius: {Radius} | X: {X} | Y: {Y} | Inner char: {InnerChar} | Inner foreground color: {InnerForgroundColor} | Inner background color: {InnerBackgroundColor} | Outer char: {OuterChar} | Outer foreground color : {OuterForgroundColor} | Outer background color : {OuterBackgroundColor}");
            Console.ResetColor();
        }

        public override void EditInfo()
        {
            string attributeToChange = SelectAttributeToChange("Radius", "X", "Y", "OuterChar", "OuterBackgroundColor", "OuterForgroundColor", "InnerChar", "InnerBackgroundColor", "InnerForgroundColor", "Change internal index");
            this.ChangeAttribute(attributeToChange);
            ShapeManagerUtils.ShowEditSuccessMessage();
        }

        private void ChangeAttribute(string attributeToChange)
        {
            switch (attributeToChange)
            {
                case "Radius":
                    this.Radius = ShapeManagerUtils.GetIntInputFromUser("radius", 1, int.MaxValue);
                    break;
                case "X":
                    this.X = ShapeManagerUtils.GetIntInputFromUser("X", int.MinValue, int.MaxValue);
                    break;
                case "Y":
                    this.Y = ShapeManagerUtils.GetIntInputFromUser("Y", int.MinValue, int.MaxValue);
                    break;
                case "OuterChar":
                    this.OuterChar = ShapeManagerUtils.GetCharInputFromUser("outer char");
                    break;
                case "OuterBackgroundColor":
                    this.OuterBackgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("outer", "background");
                    break;
                case "OuterForgroundColor":
                    this.OuterForgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("outer", "forground");
                    break;
                case "InnerChar":
                    this.InnerChar = ShapeManagerUtils.GetCharInputFromUser("inner char");
                    break;
                case "InnerBackgroundColor":
                    this.InnerBackgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("inner", "background");
                    break;
                case "InnerForgroundColor":
                    this.InnerForgroundColor = ShapeManagerUtils.GetColorSelectionFromUser("inner", "forground");
                    break;
            }
        }

        private void DrawBoundingBoxOnTop()
        {
            Console.SetCursorPosition(this.X, this.Y);

            int row = this.Radius * 2;
            int col = this.Radius * 2;
            char[,] circle = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (j + this.X >= Console.LargestWindowWidth || i + this.Y >= Console.LargestWindowHeight)
                    {
                        break;
                    }

                    if (i == 0 || j == 0 || i == row - 1)
                    {
                        Console.SetCursorPosition(j + this.X, i + this.Y);
                        circle[i, j] = '+';
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(circle[i, j]);
                        Console.ResetColor();
                    }

                    if (j == col - 1)
                    {
                        Console.SetCursorPosition(j + this.X, i + this.Y);
                        circle[i, j] = '+';
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(circle[i, j]);
                        Console.ResetColor();
                    }
                }

                Console.SetCursorPosition(this.X, this.Y + i);
            }
        }

        private void SetMonochromColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
