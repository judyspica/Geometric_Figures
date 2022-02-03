namespace Geometric_Figures_Homework
{
    using System;

    public class Rectangle : GeometricFigure
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }


        public override double CalculateCircumference()
        {
            return 2 * (this.Width + this.Height);
        }

        public override void Draw(bool boundingBoxActive, bool renderingActive)
        {
            if (this.X >= Console.LargestWindowWidth || this.Y >= Console.LargestWindowHeight)
            {
                return;
            }

            Console.SetCursorPosition(this.X, this.Y);
            for (int row = 1; row <= this.Height; row++)
            {
                for (int column = 1; column <= this.Width; column++)
                {
                    if (this.X + column >= Console.LargestWindowWidth) 
                    { 
                        break; 
                    }

                    if ((row == 1) || (row == this.Height))
                    {
                        Console.ForegroundColor = this.InnerForgroundColor;
                        Console.BackgroundColor = this.InnerBackgroundColor;
                        if (renderingActive)
                        {
                            this.SetMonochromeColor();
                        }

                        Console.Write(this.InnerChar);
                        Console.ResetColor();
                    }
                    else
                    {
                        if ((column == 1) || (column == this.Width))
                        {
                            Console.ForegroundColor = this.InnerForgroundColor;
                            Console.BackgroundColor = this.InnerBackgroundColor;
                            if (renderingActive)
                            {
                                this.SetMonochromeColor();
                            }

                            Console.Write(this.InnerChar);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = this.OuterForgroundColor;
                            Console.BackgroundColor = this.OuterBackgroundColor;
                            if (renderingActive)
                            {
                                this.SetMonochromeColor();
                            }

                            Console.Write(this.OuterChar);
                            Console.ResetColor();
                        }
                    }
                }

                Console.SetCursorPosition(this.X, this.Y + row);
            }

            if (boundingBoxActive)
            {
                this.DrawBoundingBoxOnTop();
            }
        }

        public override void PrintInfo(int index)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"rectangle @ index {index}: Height: {Height} | Width: {Width} | X: {X} | Y: {Y} | Inner char: {InnerChar} | Inner foreground color: {InnerForgroundColor} | Inner background color: {InnerBackgroundColor} | Outer char: {OuterChar} | Outer foreground color : {OuterForgroundColor} | Outer background color : {OuterBackgroundColor}");
            Console.ResetColor();
        }

        public override void EditInfo()
        {
            string attributeToChange = SelectAttributeToChange("Width", "Hight", "X", "Y", "OuterChar", "OuterBackgroundColor", "OuterForgroundColor", "InnerChar", "InnerBackgroundColor", "InnerForgroundColor");
            this.ChangeAttribute(attributeToChange);
            ShapeManagerUtils.ShowEditSuccessMessage();
        }

        private void DrawBoundingBoxOnTop()
        {
            Console.SetCursorPosition(this.X, this.Y);
            int row = this.Height;
            int col = this.Width;
            char[,] rectangle = new char[row, col];

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
                        rectangle[i, j] = '+';
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(rectangle[i, j]);
                        Console.ResetColor();
                    }

                    if (j == col - 1)
                    {
                        Console.SetCursorPosition(j + this.X, i + this.Y);
                        rectangle[i, j] = '+';
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(rectangle[i, j]);
                        Console.ResetColor();
                    }
                }

                Console.SetCursorPosition(this.X, this.Y + i);
            }
        }

        private void SetMonochromeColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void ChangeAttribute(string attributeToChange)
        {
            switch (attributeToChange)
            {
                case "Width":
                    this.Width = ShapeManagerUtils.GetIntInputFromUser("width", 2, int.MaxValue);
                    break;
                case "Hight":
                    this.Height = ShapeManagerUtils.GetIntInputFromUser("hight", 2, int.MaxValue);
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
    }
}
